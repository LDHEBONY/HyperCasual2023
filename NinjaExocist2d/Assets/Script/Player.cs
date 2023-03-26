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

    public float maxlife = 3;
    public float life;

    public bool isdead = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        life = maxlife;
    }

    private void Update()
    {
        if(life == 0)
        {
            if(!isdead)
            Dead();

            return;
        }
        
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.phase == InputActionPhase.Started && jumpcount < 2) {
            float high = transform.position.y;
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            //addforce를 쓰니까 연속으로 뛰었을 때 점프 가속력이 높아지는 문제가 있음
            //점프동작 후에 점프처리를 할 수 있도록 코루틴쓰는건 어떨까요??
            jumpcount++;
        }
    }

    void Dead()
    {
        isdead = true;
        Quaternion deadani = new Quaternion(0, 0, 90, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, deadani, speed * Time.deltaTime);
        //임시 애니메이션입니다. (쿼터니온을 이용한 회전 구현)

        Invoke("Destroying", 1f); // 죽기전에 쓰러지는 행동을 하고 사라지는 것을 의도
    }

    void Destroying()
    {
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpcount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            life--;
        }
    }
}
