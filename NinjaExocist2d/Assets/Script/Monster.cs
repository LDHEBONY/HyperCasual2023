using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int movespeed;
    public float life = 3;
    public float deadCount = 0;
    public bool isdead = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movespeed * Vector3.left * Time.deltaTime, Space.World);
     
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Star") {
            deadCount++;
            Destroy(collision.gameObject);
            if (life <= deadCount) {
                Dead();
            }
        }
    }

    public void Dead()
    {
        isdead = true;
        //this�� �� ��ũ��Ʈ�� �ı��ϹǷ� gameObject�� ����(= this.gameobject �ϸ� �� ��ũ��Ʈ�� ���� ������Ʈ�� �ı���<��¥�� �����ų�>)
        Destroy(this.gameObject);        
    }
}
