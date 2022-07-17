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
    public GameObject shotgun;
    public GameObject grenade;

    public AK.Wwise.Event hit;
    public AK.Wwise.Event sniper_hit;
    public AK.Wwise.Event ranger_hit;
    public AK.Wwise.Event charger_hit;

    private void OnEnable()
    {
        player.GetComponent<Entity>().OnHit += PlayerHit;
        sniper.GetComponent<Entity>().OnHit += SniperHit;
        ranger.GetComponent<Entity>().OnHit += RangerHit;
        charger.GetComponent<Entity>().OnHit += ChargerHit;

    }

    public void PlayerHit()
    {
        hit.Post(player);
    }
    public void SniperHit()
    {
        hit.Post(player);
    }
    public void RangerHit()
    {
        hit.Post(player);
    }
    public void ChargerHit()
    {
        hit.Post(player);
    }

    private void OnDisable()
    {
        player.GetComponent<Entity>().OnHit -= PlayerHit;
        sniper.GetComponent<Entity>().OnHit -= SniperHit;
        ranger.GetComponent<Entity>().OnHit -= RangerHit;
        charger.GetComponent<Entity>().OnHit -= ChargerHit;
    }
}
