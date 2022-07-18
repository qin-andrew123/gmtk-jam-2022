using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using AK.Wwise;

public class HUDManager : MonoBehaviour
{

    public GameObject[] attackIconsIntro = new GameObject[3];
    public GameObject[] movementIconsIntro = new GameObject[3];
    
    public GameObject[] attackIconsHud = new GameObject[3];
    public GameObject[] movementIconsHud = new GameObject[3];

    public GameObject introPanel;
    public GameObject hudPanel;

    public Image healthBar;

    public GameObject player;

    private int currentAttackIcon = 0;
    private int currentMovementIcon = 0;
    
    public Sprite[] healthSprites;
    
    private void OnEnable()
    {
        player.GetComponent<PlayerAbilityController>().OnAbilityChange += ChangeIcons;
        //player.GetComponent<Entity>().OnHit += ChangeValue;
    }

    private void OnDisable()
    {
        player.GetComponent<PlayerAbilityController>().OnAbilityChange -= ChangeIcons;
    }

    private void Start()
    {
        StartCoroutine(HitPlayer());
    }

    private void ChangeIcons(int ability, int weapon)
    {
        attackIconsIntro[currentAttackIcon].SetActive(false);
        movementIconsIntro[currentMovementIcon].SetActive(false);
        attackIconsHud[currentAttackIcon].SetActive(false);
        movementIconsHud[currentMovementIcon].SetActive(false);

        currentAttackIcon = weapon;
        currentMovementIcon = ability;
        
        attackIconsIntro[currentAttackIcon].SetActive(true);
        movementIconsIntro[currentMovementIcon].SetActive(true);
        attackIconsHud[currentAttackIcon].SetActive(true);
        movementIconsHud[currentMovementIcon].SetActive(true);
        
        StartCoroutine(SwitchPanels());
  
        
;    }

    IEnumerator SwitchPanels()
    {
        yield return new WaitForSeconds(3f);
        introPanel.SetActive(false);
        hudPanel.SetActive(true);
        
    }

    IEnumerator HitPlayer()
    {
        yield return new WaitForSeconds(5f);
        player.GetComponent<Entity>().TakeDamage(20);
    }

    private void ChangeValue(int amount)
    {
        switch (amount)
        {
            case >=100:
                healthBar.sprite = healthSprites[0];
                break;
            case >80 and <100:
                healthBar.sprite = healthSprites[1];
                break;
            case >60 and <80:
                healthBar.sprite = healthSprites[2];
                break;
            case >40 and <60:
                healthBar.sprite = healthSprites[3];
                break;
            case >0 and <40:
                healthBar.sprite = healthSprites[4];
                break;
            case <=0:
                healthBar.sprite = healthSprites[5];
                break;
        }
    }
}
