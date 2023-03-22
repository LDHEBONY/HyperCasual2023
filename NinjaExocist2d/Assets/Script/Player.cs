using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.phase == InputActionPhase.Started) {
            if (jumpcount <= 1)
            {
                rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                jumpcount++;
            }
        }
    }

    //public void CharMove()
    //{
    //    transform.Translate(speed * Vector3.right * Time.deltaTime, Space.World);
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpcount = 0;
        }
    }
}
