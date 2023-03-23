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
        //this는 이 스크립트를 파괴하므로 gameObject로 변경(= this.gameobject 하면 이 스크립트가 속한 오브젝트를 파괴함<어짜피 같은거네>)
        Destroy(this.gameObject);        
    }
}
