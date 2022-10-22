using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimySpawning : MonoBehaviour
{
    public GameObject Prefab;
    public float speed, Nxt;
    private float timer = 2;
    void Start()
    {
        Nxt = Time.time + 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > Nxt)
        {
            Nxt = Time.time + timer;
            Spawnning();
        }
    }
    public void Spawnning() 
    {
        int j = Random.Range(0, 4);
        int i = Random.Range(1, 5);
        GameObject Bullet;
        switch (j)
        {
            case 0:
                Bullet = Instantiate(Prefab, position: new Vector2(5,-3 + i), Quaternion.Euler(0, 0, 0));
                Bullet.GetComponent<EnimyControler>().Movement = new Vector2(-speed, 0);
                break;
            case 1:
                Bullet = Instantiate(Prefab, position: new Vector2(-5, -3 + i), Quaternion.Euler(0, 0, 0));
                Bullet.GetComponent<EnimyControler>().Movement = new Vector2(speed, 0);
                break;
            case 2:
                Bullet =  Instantiate(Prefab, position: new Vector2(-3 + i, 5), Quaternion.Euler(0, 0, 0));
                Bullet.GetComponent<EnimyControler>().Movement = new Vector2(0, -speed);
                break;
            case 3:
                Bullet =  Instantiate(Prefab, position: new Vector2(-3 + i, -5), Quaternion.Euler(0, 0, 0));
                Bullet.GetComponent<EnimyControler>().Movement = new Vector2(0, speed);
                break;
        }
        if (timer >= 0.5f)
        {
            timer -= 0.05f;
        }
    }
}
