using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    protected EnemyWeapon _enemyWeapon;

    protected abstract void OnTriggerStay2D(Collider2D other);

    protected abstract void AttackPlayer();
    protected abstract void SetHP();
}
