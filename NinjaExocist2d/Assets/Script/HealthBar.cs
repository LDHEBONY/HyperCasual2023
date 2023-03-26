using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    Slider healthbar;

    [SerializeField] 
    TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.value = player.life;
        healthbar.maxValue = player.maxlife;
        healthText.text = $"{healthbar.value} / {healthbar.maxValue}";
    }
}
