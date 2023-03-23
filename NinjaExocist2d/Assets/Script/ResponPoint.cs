using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponPoint : MonoBehaviour
{

    [SerializeField]
    private GameObject mon1Prefab;
    [SerializeField]
    private GameObject mon2Prefab;
   

    public float mon1delay;
    public float mon2delay;
   

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
        //isresponed�� false�� �Ǹ� ��� �ڷ�ƾ�� �ٽ� �����ϴ� ������ ����.
        if (isresponed == false)
        {
            StartCoroutine(Spawn(mon1delay, mon1Prefab));

            StartCoroutine(Spawn(mon2delay, mon2Prefab));
        }

       
    }

    private IEnumerator Spawn(float delay, GameObject monster)
    {
        isresponed = true;
        yield return new WaitForSecondsRealtime(delay);
        Vector2 spawnvec = new Vector2(this.transform.position.x, this.transform.position.y);
        //�������ʳ����� ������ 3.5�� �����س��ҽ��ϴ�.
        //�±׷� �����ؾ���(���Ͷ�� �±׷� ����, �Ӽ��� �־��ִ°� ���� ��)
        GameObject newenemy = Instantiate(monster, spawnvec, Quaternion.identity);
        isresponed = false;

        //StartCoroutine(Spawn(delay, monster)); �ڷ�ƾ �Լ� �������� �ڷ�ƾ�� �� ����
        yield return StartCoroutine(Spawn(delay, monster)); // �ڷ�ƾ �Լ� ������ �� �����ϱ� ���� ��� �� ���� �ڷ�ƾ ����
    }
}
