using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranger : Enemy
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    [SerializeField] protected float retreatDistance;
    private Vector2 movement;
    public override void Attack()
    {
        Vector2 attackDirection = (player.position - transform.position).normalized;
        animator.SetBool("isShooting", true);
        InstantiateBullet(attackDirection);
    }
    
    private void InstantiateBullet(Vector2 dir)
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
    }

    public override void Move()
    {
        Vector2 velocity = (player.position - transform.position).normalized;
        Vector2 movement = transform.position - player.position; ;
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            animator.SetBool("isInRange", true);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && 
                 Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            //transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            animator.SetBool("isInRange", true);
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isInRange", false);
        }
    }
}
