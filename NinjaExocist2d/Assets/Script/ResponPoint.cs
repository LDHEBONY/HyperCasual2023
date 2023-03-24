using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������ʳ����� ������ 3.5
public class ResponPoint : MonoBehaviour
{

    [SerializeField]
    private GameObject mon1Prefab;
    [SerializeField]
    private GameObject mon2Prefab;
   
    public float mon1delay;
    public float mon2delay;
   
    void Start()
    {
        StartCoroutine(Spawn(mon1delay, mon1Prefab));
        StartCoroutine(Spawn(mon2delay, mon2Prefab));
    }

    private IEnumerator Spawn(float delay, GameObject monster)
    {
        while (true) {
            yield return new WaitForSecondsRealtime(delay);
            Vector2 spawnvec = new Vector2(transform.position.x, transform.position.y);
            GameObject newenemy = Instantiate(monster, spawnvec, Quaternion.identity);
            yield return new WaitForEndOfFrame();
        }
    }
}
