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
        //isresponed가 false가 되면 모든 코루틴이 다시 시작하는 문제가 있음.
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
        //리스포너끼리의 간격은 3.5로 설정해놓았습니다.
        //태그로 관리해야함(몬스터라는 태그로 통일, 속성을 넣어주는게 나을 것)
        GameObject newenemy = Instantiate(monster, spawnvec, Quaternion.identity);
        isresponed = false;

        //StartCoroutine(Spawn(delay, monster)); 코루틴 함수 스폰에서 코루틴을 또 시행
        yield return StartCoroutine(Spawn(delay, monster)); // 코루틴 함수 스폰이 다 시행하기 까지 대기 후 스폰 코루틴 시행
    }
}
