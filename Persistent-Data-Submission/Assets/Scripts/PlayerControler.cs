using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private LayerMask Ground;
    private bool PM = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0)) && PM == true)
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                Move((int)Input.GetAxisRaw("Horizontal"), 0);
            }
            else
            {
                Move(0,(int)Input.GetAxisRaw("Vertical"));
            }
        }
    }
    public void Move(int X, int Y)
    {
        bool CanMove = Physics2D.OverlapPoint(transform.position + new Vector3(X, Y), Ground);
        if (CanMove == true)
        {
            Debug.Log("Pode se mover");
            StartCoroutine(Delay());
            transform.position += new Vector3(X, Y);
        }
        else
        {
            Debug.Log("Não pode se mover");
        }
    }
    IEnumerator Delay()
    {
        PM = false;
        yield return new WaitForSeconds(0.5f);
        PM = true;
    }
}
