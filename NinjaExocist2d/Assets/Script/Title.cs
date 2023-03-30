using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    SpriteRenderer titleImage;
    // Start is called before the first frame update
    void Start()
    {
        titleImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClickGameStart()
    {
        titleImage.transform.position = new Vector3(0f, 15f);
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
