using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    float damage = 1;
    float attackSpeed = 5f;
    Collider2D col;
    Rigidbody2D rb;
    [SerializeField]
    Camera mainCamera;

    private void Start() {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(attackSpeed, 0f, 0f);

    }

    private void Update() {//if�� ���� ���� �ʿ�
        if(mainCamera.orthographicSize * 2 < transform.position.x) {
            Destroy(gameObject);
        }
    }


}
