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
    public bool isFreeze = true;

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
    public void OnCilckGameStart()
    {
        isFreeze = false;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && jumpcount < 2 && isFreeze == false) {
            //float high = transform.position.y;
            //if (jumpcount == 0) {
            rigid.velocity = Vector2.up * JumpPower;
            //}
            //else if (jumpcount == 1) {
            //    float doubleJumpRes = Mathf.Sqrt(20 * (4f - transform.position.y));
            //    rigid.velocity = Vector2.up * doubleJumpRes;
            //}

            //rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            jumpcount++;
        }
    }

    void Dead()
    {
        isdead = true;
        Quaternion deadani = new Quaternion(0, 0, 90, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, deadani, speed * Time.deltaTime);
        //�ӽ� �ִϸ��̼��Դϴ�. (���ʹϿ��� �̿��� ȸ�� ����)

        Invoke("Destroying", 1f); // �ױ����� �������� �ൿ�� �ϰ� ������� ���� �ǵ�
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
