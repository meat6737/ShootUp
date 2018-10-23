using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AimerControl : MonoBehaviour {
    public int Life;
    public int Power;
    Vector3 currentPos;
    Vector3 targetPos;
    Rigidbody rgbody;
    public float shootdelay;
    public Bullet bullet;
    public float MoveSpeed;
    public Transform FirePos;
    public static UnityAction Upgrade;
    public Text PowerStat;
    public Text RateStat;

    void Start()
    {
        Upgrade += () =>
        {
            shootdelay -= 0.05f;
            if (shootdelay <= 0.1f) shootdelay = 0.1f;
            Power += 1;
        };
        Power = 5;
        rgbody = GetComponent<Rigidbody>();
        currentPos= new Vector3(Screen.width / 2, transform.position.y, transform.position.z);
        targetPos = new Vector3(Screen.width / 2, transform.position.y, transform.position.z);
        StartCoroutine(Fire());
       
    }
    void Update()
    {
        if (GameControl.Instance.gameState == GameState.Game)
        {
            if (Input.GetMouseButton(0))
            {
                targetPos = Input.mousePosition;
            }
            Move();
        }
        ShowStatus();
    }
    void Move()
    {
        float mouseX = Camera.main.ScreenToWorldPoint(targetPos).x;
        float posX = transform.position.x;
        if (Mathf.Abs(mouseX - posX) < 0.1f)
            return;
        Vector3 targetVec = new Vector3(mouseX - posX, transform.position.y, transform.position.z).normalized*MoveSpeed*Time.deltaTime;
        Vector3 MovePos = transform.position + targetVec;
        rgbody.MovePosition(new Vector3(Mathf.Clamp(MovePos.x,-2.7f,2.7f),transform.position.y,transform.position.z));
    }
    IEnumerator Fire()
    {
        while (true)
        {
            //Bullet newbullet = Resources.Load("Prefabs\\Bullet") as Bullet;            
            yield return new WaitForSeconds(shootdelay);
            Bullet bulletins=Instantiate(bullet, FirePos.transform.position, Quaternion.identity);
            bulletins.Init(Power);
        }        
    }
    public void Behit(int DMG)
    {
        Life -= DMG;
        if (Life <= 0)
        {
            Life = 0;
            
            Destroy(gameObject);
            GameControl.Instance.GameOver();
                     
        }
    }
    public void UpGrade()
    {
        shootdelay -= 0.02f;
        if (shootdelay <= 0.1f) shootdelay = 0.1f;
        Power += 1;
    }  
    void ShowStatus()
    {
        PowerStat.text = Power.ToString();
        RateStat.text = ((int)(1 / shootdelay)).ToString() + "/S";
    }
  
}
