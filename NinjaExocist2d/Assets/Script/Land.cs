using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Land : MonoBehaviour
{
    Tilemap tilemap;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        tilemap= GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    { 
        if(tilemap.tileAnchor.x > -20.5)
        {
            tilemap.tileAnchor += Vector3.left * moveSpeed * Time.deltaTime;
        }
        else
        {
            tilemap.tileAnchor = new Vector3(-0.5f,0.5f,0f);
        }

    }
}
