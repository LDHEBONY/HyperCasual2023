using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigid;
    public float JumpPower;
    public float speed;
    public int jumpcount;

    //public bool onjump;
    //public bool ondoublejump;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        //onjump = false;
        //ondoublejump = false;
    }

    // Update is called once per frame
    void Update()
    {
        CharMove();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
     
    }

    public void CharMove()
    {
        transform.Translate(speed * Vector3.right * Time.deltaTime, Space.World);
    }

    public void Jump()
    {
        if (jumpcount < 3)
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            jumpcount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpcount = 0;
        }
    }
}
