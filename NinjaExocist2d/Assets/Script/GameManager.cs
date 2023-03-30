using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public Player player;
    public ThrowStars throwStars;
    public HealthBar healthBar;
    public Title title;
    public ResponPoint[] responPoints;

    public int totalscore = 0;
    public float timeflow = 0;

    public GameObject readyText;
    public GameObject startText;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TimeText;

    public GameObject resultUI;

    public bool countStart = false;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    void Update() {
        if (countStart) {
            FlowTime();
        }
        if (player.isdead == true) {
            GameOver();
        }
    }

    public static GameManager Instance { get { return instance; } }

    public void FlowTime() {
        timeflow += Time.deltaTime;
        TimeText.text = "" + Mathf.Round(timeflow);
        //TimeTextMinute.text = "";
    }

    public void AddScore(int score) {
        totalscore += score;
        scoreText.text = "Score: " + totalscore;


    }

    public void ThrowAndSpawnStart()
    {
        throwStars.throwStart = true;
        for (int i = 0; i < responPoints.Length; i++)
        {
            responPoints[i].isStart= true;
            responPoints[i].SpawnStart();
        }
    }

    public void OnCilckGameStart()
    {
        player.OnCilckGameStart();
        title.OnClickGameStart();
        healthBar.OnCilckGameStart();
        TimeText.transform.parent.gameObject.SetActive(true);
        scoreText.transform.parent.gameObject.SetActive(true);
        Invoke("GameStart", 3f);
    }

    public void OnClickRestart() {

        totalscore = 0;
        timeflow = 0;
}

    public void GameStart() {
        countStart = true;
        ThrowAndSpawnStart();

    }

    public void GameOver() {
        Time.timeScale = 0f;
        countStart = false;
        resultUI.gameObject.SetActive(true);
    }


}
