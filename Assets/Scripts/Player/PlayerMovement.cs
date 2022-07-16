using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
    Idle,
    Moving,

}

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private float collisionOffset = 0.01f;
    private Vector2 mousePosition;
    private Vector2 movementDirection;
    private MoveSpeed moveSpeed;
    private MovementState currentState;
    private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    public Rigidbody2D rigidBody;
    public Camera playerCamera;
    

    private void Start()
    {
        moveSpeed = GetComponent<MoveSpeed>();
    }
    void Update()
    {
        GetInputValue();
        mousePosition = playerCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (movementDirection != Vector2.zero)
        {
            bool success = TryToMovePlayer(movementDirection);
            if (!success)
            {
                success = TryToMovePlayer(new Vector2(movementDirection.x, 0));
                if (!success)
                {
                    success = TryToMovePlayer(new Vector2(0, movementDirection.y));
                }
            }
        }
        
        Vector2 lookDirection = mousePosition - rigidBody.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rigidBody.rotation = angle;
    }

    // receives input value each frame and puts into these two floats 
    private void GetInputValue()
    {
        movementDirection.x = Input.GetAxisRaw("Horizontal");
        movementDirection.y = Input.GetAxisRaw("Vertical");
    }

    private bool TryToMovePlayer(Vector2 direction)
    {
        int count = rigidBody.Cast(direction, movementFilter, castCollisions, playerMoveSpeed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            rigidBody.MovePosition(rigidBody.position + playerMoveSpeed * Time.fixedDeltaTime * direction);
            return true;
        }
        else
        {
            return false;
        }
    }


}
