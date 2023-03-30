using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    public Player player;

    public int totalscore = 0;
    public float timeflow = 0;

    public Text scoretext;
    public Text Timetext;
    //public Text TimeTextMinute;


    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FlowTime();

        if (player.isdead == true)
        {
            Time.timeScale = 0f; // �ܼ� Ÿ�ӽ������� 0���� �� ��, �ڷ�ƾ�� ��� ���ư��� ������ ����
        }
    }

    public void FlowTime()
    {
        timeflow += Time.deltaTime;
        Timetext.text = "" + Mathf.Round(timeflow);
        //TimeTextMinute.text = "";
    }

    public void AddScore(int score)
    {
        totalscore += score;
        scoretext.text = "Score: " + totalscore;
    }
}
