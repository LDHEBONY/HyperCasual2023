using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int movespeed;
    public float life;
    public float maxlife = 3;
    public bool isdead = false;

    private void Start()
    {
        life = maxlife; // �����Ҷ� �ִ�ü�� �����ϰ� �������� ���̵��� �����߽��ϴ�.
    }

    void Update()
    {
        transform.Translate(movespeed * Vector3.left * Time.deltaTime, Space.World);
     
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Star") {
            life--;
            Destroy(collision.gameObject);
            if (life <= 0) {
                Dead();
            }
        }
    }



    public void Dead()
    {
        isdead = true;
        Destroy(gameObject);        
    }
}
