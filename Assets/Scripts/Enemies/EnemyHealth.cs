using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    short _enemyMaxHP;
    short _enemyCurrentHP;

	public short MaxHP
    {
        get { return _enemyMaxHP; }
        set { _enemyMaxHP = value; }
    }

    public short CurrentHP
    {
        get { return _enemyCurrentHP; }
        set { _enemyCurrentHP = value; }
    }

    public void DealDamageToEnemy(short damage)
    {
        _enemyCurrentHP -= damage;
        if (IsDead())
        {
            Points p = gameObject.GetComponent<Points>();
            PlayerScore.AddPoints(p.Amount);
            HUD.UpdateScore();
            Destroy(gameObject);
        }                           
    }

    private bool IsDead()
    {
        if (_enemyCurrentHP <= 0)
            return true;
        else
            return false;
    }
}
