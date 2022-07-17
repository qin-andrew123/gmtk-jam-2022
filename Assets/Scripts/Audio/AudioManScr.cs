using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManScr : MonoBehaviour
{
    public GameObject player;
    public GameObject sniper;
    public GameObject ranger;
    public GameObject charger;

    public GameObject weapon1;
    public GameObject weapon2;
    public GameObject weapon3;

    public AK.Wwise.Event hit;
    public AK.Wwise.Event sniper_hit;
    public AK.Wwise.Event ranger_hit;
    public AK.Wwise.Event charger_hit;

    private void OnEnable()
    {
        player.GetComponent<Entity>().OnHit += PlaySound;
        sniper.GetComponent<Entity>().OnHit += PlaySound;
        ranger.GetComponent<Entity>().OnHit += PlaySound;
        charger.GetComponent<Entity>().OnHit += PlaySound;
    }

    public void PlaySound()
    {
        hit.Post(player);
        sniper_hit.Post(sniper);
        ranger_hit.Post(ranger);
        charger_hit.Post(charger);
    }

    private void OnDisable()
    {
        player.GetComponent<Entity>().OnHit -= PlaySound;
        player.GetComponent<Entity>().OnHit -= PlaySound;
        sniper.GetComponent<Entity>().OnHit -= PlaySound;
        ranger.GetComponent<Entity>().OnHit -= PlaySound;
        charger.GetComponent<Entity>().OnHit -= PlaySound;
    }
}
