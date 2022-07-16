using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunWeapon : Weapon
{
    public float shootAngle;

    public int ammo = 4;

    // angle in degrees
    public Vector2 DirectionFromAngle(float angle)
    {
        return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
    }
    
    protected override void Shoot()
    {
        for (int i = 0; i < ammo; ++i)
        {
            float angle = Random.Range(-shootAngle / 2, shootAngle / 2);
            Vector2 dir = DirectionFromAngle(angle);
            
            GameObject bullet = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up + dir * bulletSpeed, ForceMode2D.Impulse);
        }

    }
}
