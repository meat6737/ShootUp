using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public int damage;
    Text ScoreBoard;
    ParticleSystem BoomVFX;
    public int Health;
    Rigidbody rgbody;
    public int MoveSpeed;
    Text Healthtxt;
    Text Healthtxtins;
    public AudioClip audioclip;
    float AudioVolume;
    Color color1;
    List<Color> colorList;
    private void Awake()
    {
        AudioVolume = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>().volume;
        colorList = new List<Color>();
        Color color1 = new Color(166f / 255f, 99f / 255f, 168f / 255f);
        Color color2 = new Color(99f / 255f, 115f / 255f, 168f / 255f);
        Color color3 = new Color(134f / 255f, 168f / 255f, 99f / 255f);
        Color color4 = new Color(99f / 255f, 168f / 255f, 152f / 255f);
        Color color5 = new Color(168f / 255f, 102f / 255f, 99f / 255f);
        colorList.Add(color1);
        colorList.Add(color2);
        colorList.Add(color3);
        colorList.Add(color4);
        colorList.Add(color5);

    }
    void Start()
    {
        GetComponent<AudioSource>().volume = AudioVolume;
    }
    void Update()
    {
        Vector3 scrPos = Camera.main.WorldToScreenPoint(transform.position);
        if (scrPos.y <=-Screen.height/2)
        {
            Destroy(Healthtxtins.gameObject);
            Destroy(gameObject);
        }
        Move();
        Vector3 scrpos = Camera.main.WorldToScreenPoint(transform.position);
        Healthtxtins.transform.position = scrpos;
        Healthtxtins.text = Health.ToString();
        

    }
    void Move()
    {

        rgbody.velocity = new Vector3(0, -1, 0) * MoveSpeed;
        //rgbody.MovePosition(transform.position+new Vector3(0, -1, 0) * MoveSpeed * Time.deltaTime);
    }
    public void Init(int Health,int MoveSpeed,int damage)
    {
        this.Health = Health;
        this.MoveSpeed = MoveSpeed;
        this.damage = damage;
        ScoreBoard = GameObject.Find("ScoreBoard").GetComponent<Text>();
        BoomVFX = Resources.Load<ParticleSystem>("Prefabs\\Boom");
        BoomVFX.gameObject.GetComponent<AudioSource>().volume = AudioVolume;
        rgbody = GetComponent<Rigidbody>();
        Vector3 text = Camera.main.WorldToScreenPoint(transform.position);
        Transform canvas = GameObject.FindWithTag("UIRoot").transform;
        Healthtxt = Resources.Load<Text>("Prefabs\\Healthnum");
        Healthtxtins = Instantiate(Healthtxt, transform.position, transform.rotation, canvas);
        GetComponent<MeshRenderer>().material.color = colorList[(int)Random.Range(1,5)];
    }
    public void Behit(int power)
    {
        GetComponent<AudioSource>().PlayOneShot(audioclip);
        int score = int.Parse(ScoreBoard.text);
        if (Health < power) score += Health;
        else score += power;        
        ScoreBoard.text = score.ToString();
        GameControl.Instance.score = score;
        Health -= power;
        if (Health <= 0)
        {
            Health = 0;
            AimerControl.Upgrade();
            Instantiate(BoomVFX, transform.position, transform.rotation);
            
            Destroy(Healthtxtins.gameObject);
            Destroy(gameObject);
            
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        other.GetComponent<AimerControl>().Behit(damage);   
    }    
}
