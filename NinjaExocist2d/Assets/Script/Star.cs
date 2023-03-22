using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    float damage = 1;
    float attackSpeed = 5f;
    Collider2D col;
    Rigidbody2D rb;

    private void Start() {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(attackSpeed, 0f, 0f);

    }

    private void Update() {
        
    }


}
