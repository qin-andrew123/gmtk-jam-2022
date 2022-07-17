using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Abilities/Teleport")]
public class TeleportAbility : Ability
{
    public override void Activate(GameObject parent)
    {
        base.Activate(parent);
        int radius = 1;
        while(Physics2D.OverlapCircleAll(parent.transform.position, radius, LayerMask.GetMask("Enemy")).Length == 0)
            radius++;

        Collider2D[] objectsInRange = Physics2D.OverlapCircleAll(parent.transform.position, radius, LayerMask.GetMask("Enemy"));

        var index = Random.Range (0, objectsInRange.Length);
        Transform enemyTransform = objectsInRange[index].GetComponent<Transform>();
        parent.transform.position = (Vector2)enemyTransform.transform.position + Vector2.right;
    }
}
