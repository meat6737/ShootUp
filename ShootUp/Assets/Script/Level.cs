using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {
    public float increment;
    public float incLevel;
    public Enemy Enemy;
    public float NormalWait;    
    
    void Start()
    {
        increment = 20;
        NormalWait = 5f;        
        StartCoroutine(NormalLevel());
        StartCoroutine(VarySpdLevel());
        StartCoroutine(StockLevel());
    }
    void Update()
    {
                
    }
    IEnumerator StartGame()
    {
        while (true)
        {            
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
            {
                Enemy enemy = new Enemy();
                List<Enemy> enemies = new List<Enemy>();
                enemies.Add(Instantiate(Enemy, transform.position, Quaternion.identity));
                float bound = Enemy.GetComponent<Renderer>().bounds.size.x;
                for (int i = 1; i < 3; i++)
                {
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x + bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x - bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                }
                int sum = (int)increment;
                for (int i = 0; i < enemies.Count; i++)
                {
                    int value = Random.Range(4 - i + 1, sum + 1 - (4 - i) - (4 - i));
                    enemies[i].Init(value, 5, 1);
                    sum -= value;
                }
                increment += incLevel;
                if(incLevel<=5f) incLevel += 0.1f;
                if (NormalWait >= 2) NormalWait -= 0.1f;
            }
            
            yield return new WaitForSeconds(NormalWait);
            
            
        }        
    }

    
    IEnumerator NormalLevel()
    {
        while (true)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
            {
                Enemy enemy = new Enemy();
                List<Enemy> enemies = new List<Enemy>();
                enemies.Add(Instantiate(Enemy, transform.position, Quaternion.identity));
                float bound = Enemy.GetComponent<Renderer>().bounds.size.x;
                for (int i = 1; i < 3; i++)
                {
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x + bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x - bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                }
                int sum = (int)increment;
                for (int i = 0; i < enemies.Count; i++)
                {
                    int value = Random.Range(4 - i + 1, sum + 1 - (4 - i) - (4 - i));
                    enemies[i].Init(value, 5, 1);
                    sum -= value;
                }                
                increment += incLevel;
                if (incLevel <= 5f) incLevel += 0.1f;
                if (NormalWait >= 2) NormalWait -= 0.1f;
            }
            yield return new WaitForSeconds(NormalWait);
        }
    }
    IEnumerator VarySpdLevel()
    {
        
        while (true)
        {           
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
            {
                Enemy enemy = new Enemy();
                List<Enemy> enemies = new List<Enemy>();
                enemies.Add(Instantiate(Enemy, transform.position, Quaternion.identity));
                float bound = Enemy.GetComponent<Renderer>().bounds.size.x;
                for (int i = 1; i < 3; i++)
                {
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x + bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x - bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                }
                int sum = (int)increment;
                for (int i = 0; i < enemies.Count; i++)
                {
                    int speed = Random.Range(1, 6);
                    int value = Random.Range(4 - i + 1, sum + 1 - (4 - i) - (4 - i));
                    enemies[i].Init(value, speed, 1);
                    sum -= value;
                }
                increment += incLevel;
                if (incLevel <= 5f) incLevel += 0.1f;
            }
            float WaitTime = Random.Range(2, 5) * NormalWait - 1;
            yield return new WaitForSeconds(WaitTime);
        }
    }
    IEnumerator StockLevel()
    {
        while (true)
        {            
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < 3)
            {
                Enemy enemy = new Enemy();
                List<Enemy> enemies = new List<Enemy>();
                enemies.Add(Instantiate(Enemy, transform.position, Quaternion.identity));               
                float bound = Enemy.GetComponent<Renderer>().bounds.size.x;
                float height = Enemy.GetComponent<Renderer>().bounds.size.y;
                enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x, transform.position.y + height + 0.1f, transform.position.z), Quaternion.identity));
                for (int i = 1; i < 3; i++)
                {
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x + bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x + bound * i, transform.position.y + height * i + 0.1f, transform.position.z), Quaternion.identity));
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x - bound * i, transform.position.y, transform.position.z), Quaternion.identity));
                    enemies.Add(Instantiate(Enemy, new Vector3(transform.position.x - bound * i, transform.position.y + height * i + 0.1f, transform.position.z), Quaternion.identity));
                }
                int sum = (int)increment*2;
                for (int i = 0; i < enemies.Count-1; i++)
                {                    
                    int value = Random.Range(1, sum + 1 - (9 - i)*4);
                    enemies[i].Init(value, 5, 1);
                    sum -= value;
                }
                enemies[enemies.Count-1].Init(sum, 5, 1);
                increment += incLevel;
                if (incLevel <= 5f) incLevel += 0.1f;
            }
            float WaitTime = Random.Range(2, 5) * NormalWait - 3;
            yield return new WaitForSeconds(WaitTime);
        }
    }
   

}
