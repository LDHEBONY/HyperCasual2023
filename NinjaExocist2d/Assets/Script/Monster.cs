using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int movespeed;

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

    public void Dead()
    {
        isdead = true;
        Destroy(this);        
    }
}
