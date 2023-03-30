using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ThrowStars throwStars;
    public HealthBar healthBar;
    public Title title;
    public ResponPoint[] responPoints;
    public GameObject readyText;
    public GameObject startText;

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
        Invoke("ThrowAndSpawnStart", 3f);

    }


}
