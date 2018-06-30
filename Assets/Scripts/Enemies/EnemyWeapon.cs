using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon
{
    short _weaponDamage;
    float _weaponFireRate;

    public short Damage
    {
        get { return _weaponDamage; }
    }

    public float FireRate
    {
        get { return _weaponFireRate; }
    }

    public static EnemyWeapon CreatePistol()
    {
        EnemyWeapon enemyPistol = new EnemyWeapon();
        enemyPistol._weaponDamage = 10;
        enemyPistol._weaponFireRate = 0.45f;
        return enemyPistol;
    }

    public static EnemyWeapon CreateMachinegun()
    {
        EnemyWeapon enemyMachinegun = new EnemyWeapon();
        enemyMachinegun._weaponDamage = 20;
        enemyMachinegun._weaponFireRate = 0.25f;
        return enemyMachinegun;
    }
}
