using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Weapon attribute
    private int damage;
    public float fireRate;
    public float spread;
    private bool canShoot;

    // Bullet attributes
    public float bulletSpeed = 20f;
    public Transform firePosition;
    public GameObject bulletPrefab;

    private void Start()
    {
        canShoot = true;
    }

    public void Update()
    {
        if (Input.GetButton("Fire1") && canShoot)
            StartCoroutine(FireWeapon());
    }

    protected abstract void Shoot();
    
    protected IEnumerator FireWeapon()
    {
        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
