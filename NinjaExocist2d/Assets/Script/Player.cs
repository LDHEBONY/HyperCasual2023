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
            //addforce�� ���ϱ� �������� �پ��� �� ���� ���ӷ��� �������� ������ ����
            //�������� �Ŀ� ����ó���� �� �� �ֵ��� �ڷ�ƾ���°� ����??
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
