using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float classBulletSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float timeTillDestroy;
    Vector2 difference;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (rb != null)
        {
            Debug.Log("RigidBody is not null");
            rb.velocity = difference * classBulletSpeed * Time.fixedDeltaTime;
        }
    }

    private void OnEnable()
    {
        difference = (Vector2) (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.position;
        difference.Normalize();
        StartCoroutine(DestroyTimer(timeTillDestroy));
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Obstacles"))
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DestroyTimer(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(this.gameObject);
    }
}
