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

    void Start()
    {
        if(attackRoutine == null) {
            attackRoutine = attack();
            StartCoroutine(attackRoutine);
        }
    }

    IEnumerator attack() {
        float maxNum = starsNum;
        float currentNum = maxNum;
        while (true) {
            while (currentNum > 0) {
                currentNum--;
                ThrowStar();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.5f);
            maxNum = starsNum;
            currentNum = maxNum;
        }

    }

    void ThrowStar() {
        Instantiate(star, attackPos);
    }
}
