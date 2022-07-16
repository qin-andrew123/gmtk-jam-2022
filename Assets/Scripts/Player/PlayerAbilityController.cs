using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityController : MonoBehaviour
{
    // create movement abilities aswell
    public GameObject[] weaponPrefabs;
    public GameObject selectedWeapon;

    public Transform weaponTransform;

    // Start is called before the first frame update
    void Awake()
    {
        selectedWeapon = Instantiate(weaponPrefabs[0], weaponTransform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChoseCombatAbility()
    {
        if (selectedWeapon != null)
            Destroy(selectedWeapon);
        int[] choice = Die.RollDice(weaponPrefabs.Length, 1);
        selectedWeapon = Instantiate(weaponPrefabs[choice[0]], weaponTransform.position, Quaternion.identity);
        selectedWeapon.transform.SetParent(transform);
    }
}
