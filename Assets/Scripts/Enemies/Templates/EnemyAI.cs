using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    RaycastHit2D[] _rays;

    public void CastRays(Vector2 playerPosition)
    {
        Vector2 selfPosition = gameObject.transform.position;
        Vector2 targetDirection = playerPosition - selfPosition;
        float distanceToPlayer = Vector2.Distance(selfPosition, playerPosition);
        _rays = Physics2D.RaycastAll(selfPosition, targetDirection, distanceToPlayer);
    }

    public virtual bool CanPlayerBeSeen()
    {
        for (int i = 0; i < _rays.Length; i++)
        {
            if (_rays[i].collider.gameObject.layer == 0)
                    return false;
        }     
        return true;
    }

    public virtual void MoveTowardsPlayer(Vector2 playerPosition)
    {
        Vector2 selfPosition = gameObject.transform.position;
        Vector2 targetDirection = playerPosition - selfPosition;
        targetDirection.Normalize();
        transform.Translate(targetDirection * 0.01f);        
    }
}
