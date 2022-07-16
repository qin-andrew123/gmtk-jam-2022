using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed : MonoBehaviour
{
    private float enemyMoveSpeed;
    public float GetPlayerMoveSpeed()
    {
        return enemyMoveSpeed;
    }
    public void SetPlayerMoveSpeed(float desiredSpeed)
    {
        enemyMoveSpeed = desiredSpeed;
    }
}
