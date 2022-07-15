using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerMoveSpeed;
    private float horizontalInput;
    private float verticalInput;
    private Vector2 mousePosition;

    public Rigidbody2D rigidBody;
    public Camera playerCamera;

    public float GetPlayerMoveSpeed()
    {
        return playerMoveSpeed;
    }
    public void SetPlayerMoveSpeed(float desiredSpeed)
    {
        playerMoveSpeed = desiredSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GetInputValue();
        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;
    }

    private void GetInputValue()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        Vector2 movementDirection = new Vector2(horizontalInput,verticalInput);
        rigidBody.MovePosition(rigidBody.position + movementDirection * playerMoveSpeed * Time.fixedDeltaTime);
    }
}
