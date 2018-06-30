using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSoldierAI : EnemyAI
{
    public override void MoveTowardsPlayer(Vector2 playerPosition)
    {
        Vector2 selfPosition = gameObject.transform.position;
        Vector2 targetDirection = playerPosition - selfPosition;
        targetDirection.Normalize();
        transform.Translate(targetDirection * 0.03f);
    }
}
