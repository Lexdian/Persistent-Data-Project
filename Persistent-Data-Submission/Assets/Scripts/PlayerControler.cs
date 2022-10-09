using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    private LayerMask Ground;
    [SerializeField]
    private Vector3 Target;
    public float speed;
    private int Pontos;
    public TextMeshProUGUI tmp;
    [SerializeField]
    private bool IsDead;
    // Start is called before the first frame update
    void Start()
    {
        Target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Input.GetAxisRaw("Horizontal") != 0) || (Input.GetAxisRaw("Vertical") != 0)) && transform.position == Target)
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
        Pontos = (int)Time.time;
        if (IsDead == false)
        {
            tmp.text = Pontos.ToString();
        }
    }
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target, speed);
    }
    public void Move(int X, int Y)
    {
        bool CanMove = Physics2D.OverlapPoint(transform.position + new Vector3(X, Y), Ground);
        if (CanMove == true)
        {
            Debug.Log("Pode se mover");
            Target += new Vector3(X, Y);
        }
        else
        {
            Debug.Log("Não pode se mover");
        }
    }
    public void Morreu()
    {
        PersistentData.PD.Pontos = Pontos;
    }
}
