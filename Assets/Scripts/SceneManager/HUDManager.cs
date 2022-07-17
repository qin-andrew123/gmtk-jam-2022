using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HUDManager : MonoBehaviour
{
    private Image healthbar = null;
    private Image movementAbility = null;
    private Image attackAbility = null;
    private Text timeText = null;
    private GameObject panelIntro = null;
    private GameObject panelHUD = null;
    private GameObject panelDeath = null;
    
    private float timeInLevel;
    // Start is called before the first frame update
    private float currentHealthValue;
    private float newHealthValue = 100;
    public Entity player;
    
    private float startTime;
    void Start()
    {
        panelIntro = GameObject.Find("PanelIntro");
        panelHUD = GameObject.Find("PanelHUD");
        panelIntro.SetActive(true);
        panelHUD.SetActive(false);
        // set variable startTime to the current time
        startTime = Time.time;

        healthbar = GameObject.Find("Healthbar").GetComponent<Image>();

        attackAbility = GameObject.Find("AttackIcon").GetComponent<Image>();
        movementAbility = GameObject.Find("MovementIcon").GetComponent<Image>();

        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        // for two seconds after the game starts hide GameObject Abilities        
        // // change the image to be a red heart
        // heart1.sprite = Resources.Load<Sprite>("Sprites/heart_red");
    }

    
    void Update()
    {
        AddTime();
        // NewBarValue(1);
        if (startTime + 2 < Time.time)
        {
            // create an if condition to check if panelIntro is active
            if (panelIntro.activeSelf)
            {
                panelIntro.SetActive(false);
                panelHUD.SetActive(true);
            }
        }
        if (currentHealthValue <= 0)
        {
            // create an if condition to check if panelIntro is active
            if (panelIntro.activeSelf)
            {
                panelIntro.SetActive(false);
                panelHUD.SetActive(true);
            }
        }
    }

    void AddTime()
    {
        if (currentHealthValue > 0)
        {
            timeInLevel += Time.deltaTime;
            // round timeInLevel to integer
            int time = (int)timeInLevel;
            timeText.text = "Time: " + time;
        }

    }

    private void ChangeValue(int amount)
    {
        currentHealthValue = amount;
    }
    // void NewBarValue(int currentHealth)
    // {
    //     // Debug.Log(currentHealth);
    //     if(currentHealthValue != currentHealth)
    //     {
    //         Debug.Log("currentHealth:" + currentHealth);
    //         // change the image of healthbar according to the newHealthValue with switch
    //         switch (currentHealth)
    //         {
    //             case >=100:
    //                 healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (5 HP)");
    //                 break;
    //             case >80 and <100:
    //                 healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (4 HP)");
    //                 break;
    //             case >60 and <80:
    //                 healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (3 HP)");
    //                 break;
    //             case >40 and <60:
    //                 healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (2 HP)");
    //                 break;
    //             case >0 and <40:
    //                 healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (1 HP)");
    //                 break;
    //             case <=0:
    //                 healthbar.sprite = Resources.Load<Sprite>("1 HP Glow");
    //                 break;
    //         }
    //     }
    // }
}
