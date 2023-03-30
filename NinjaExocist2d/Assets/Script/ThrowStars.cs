using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowStars : MonoBehaviour
{
    [SerializeField]
    Star star;
    float starsNum = 3;
    IEnumerator attackRoutine = null;
    public Transform attackPos;
    public bool throwStart = false;

    void Update()
    {
        if(attackRoutine == null && throwStart) {
            attackRoutine = attack();
            StartCoroutine(attackRoutine);
        }
    }



    IEnumerator attack() {
        float maxNum = starsNum;
        float currentNum = maxNum;
        while (true)
        {
            while (currentNum > 0)
            {
                currentNum--;
                ThrowStar();
                yield return new WaitForSeconds(0.05f);
            }
            yield return new WaitForSeconds(0.3f);
            maxNum = starsNum;
            currentNum = maxNum;
        }
    }

    public void ThrowStar() {
        Instantiate(star, attackPos);
    }
}
