using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI ScoreResult;
    public TextMeshProUGUI TimeResult;
    private void OnEnable() {
        ScoreResult.text = "Score : " + GameManager.Instance.totalscore;
        TimeResult.text = "Time : " + GameManager.Instance.timeflow;
    }
}
