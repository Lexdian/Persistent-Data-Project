using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimyControler : MonoBehaviour
{
    public Vector2 Movement;
    private Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = Movement * Time.deltaTime;
    }
}
