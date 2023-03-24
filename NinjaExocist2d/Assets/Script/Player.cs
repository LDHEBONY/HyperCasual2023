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

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.phase == InputActionPhase.Started && jumpcount < 2) {
            float high = transform.position.y;
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            //addforce�� ���ϱ� �������� �پ��� �� ���� ���ӷ��� �������� ������ ����
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
