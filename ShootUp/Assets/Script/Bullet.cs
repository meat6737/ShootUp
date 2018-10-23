using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {    
    int power;
    Rigidbody rgbody;
    public int ShootSpeed;
	// Use this for initialization
	void Start () {
        rgbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Vector3 scrpos = Camera.main.WorldToScreenPoint(transform.position);
        if (scrpos.y > Screen.height) Destroy(gameObject);
	}
    void Move()
    {
        rgbody.MovePosition(transform.position + new Vector3(0, 1, 0) * ShootSpeed * Time.deltaTime);   
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy") return;        
        other.GetComponent<Enemy>().Behit(power);
        //if (other.GetComponent<Enemy>().Health <= 0)
        //{
        //    other.GetComponent<AimerControl>().UpGrade();
        //}
        Destroy(gameObject);
    }
    public void Init(int power)
    {
        this.power = power;
    }
}
