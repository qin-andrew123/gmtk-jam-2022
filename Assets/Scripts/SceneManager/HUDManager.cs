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
    private float timeInLevel;
    // Start is called before the first frame update
    private float currentHealthValue;
    private float newHealthValue = 100;
    void Start()
    {
        // find first image oject within the HUD
        healthbar = GameObject.Find("Healthbar").GetComponent<Image>();

        attackAbility = GameObject.Find("AttackIcon").GetComponent<Image>();
        movementAbility = GameObject.Find("MovementIcon").GetComponent<Image>();

        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        
        // // change the image to be a red heart
        // heart1.sprite = Resources.Load<Sprite>("Sprites/heart_red");
        
        // // temporary code to test the HUD
        // healthbar.enabled = false;

        // Once health in GameManager is implemented this will keep track of health
        GameManager.UpdateHealth += ChangeValue;
    }

    // Update is called once per frame
    void Update()
    {
        AddTime();
        NewBarValue();
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
    void NewBarValue()
    {
        if(currentHealthValue != newHealthValue)
        {
            // change the image of healthbar according to the newHealthValue with switch
            switch (newHealthValue)
            {
                case >=100:
                    healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (5 HP)");
                    break;
                case >80 and <100:
                    healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (4 HP)");
                    break;
                case >60 and <80:
                    healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (3 HP)");
                    break;
                case >40 and <60:
                    healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (2 HP)");
                    break;
                case >0 and <40:
                    healthbar.sprite = Resources.Load<Sprite>("Sprites/Health Bar (1 HP)");
                    break;
                case <=0:
                    healthbar.sprite = Resources.Load<Sprite>("1 HP Glow");
                    break;
            }
        }
    }
}
