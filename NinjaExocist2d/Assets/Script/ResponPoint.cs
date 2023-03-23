using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponPoint : MonoBehaviour
{



    [SerializeField]
    private GameObject mon1Prefab;
    [SerializeField]
    private GameObject mon2Prefab;
    [SerializeField]
    private GameObject mon3Prefab;
    [SerializeField]
    private GameObject mon4Prefab;

    public float mon1delay = 10.0f;
    public float mon2delay = 50.0f;
    public float mon3delay = 100.0f;
    public float mon4delay = 50.0f;

    [SerializeField]
    private bool isresponed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        
    }

    private void FixedUpdate()
    {
        //isresponed가 false가 되면 모든 코루틴이 다시 시작하는 문제가 있음.
        if (isresponed == false)
        {
            StartCoroutine(Spawn(mon1delay, mon1Prefab));

            StartCoroutine(Spawn(mon2delay, mon2Prefab));

            StartCoroutine(Spawn(mon3delay, mon3Prefab));

            StartCoroutine(Spawn(mon4delay, mon4Prefab));
        }

            

    }

    private IEnumerator Spawn(float delay, GameObject monster)
    {
        isresponed = true;
        yield return new WaitForSecondsRealtime(delay);
        Vector2 spawnvec = new Vector2(this.transform.position.x, this.transform.position.y);
        //태그로 관리해야함
        if(monster.name == "Monster1")
        {
            spawnvec.y += 6f; 
        }
        if(monster.name == "Monster2")
        {
            spawnvec.y += 3f;
        }

        GameObject newenemy = Instantiate(monster, spawnvec, Quaternion.identity);
        isresponed = false;

        //StartCoroutine(Spawn(delay, monster));
    }
}
