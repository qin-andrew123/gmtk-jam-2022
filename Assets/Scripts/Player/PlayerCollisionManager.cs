using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollisionManager : MonoBehaviour
{
    private MovementState movementState;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            movementState = MovementState.Idle;
            Debug.Log("Player has collided, the movement state is: " + movementState);
        }
    }
}
