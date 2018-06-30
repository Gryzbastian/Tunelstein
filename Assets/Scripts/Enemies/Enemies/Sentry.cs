using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : Enemy
{
    float _nextShot = 0.0f;
    int _points = 50;
    AudioSource _source;

    void Start()
    {
        _enemyWeapon = EnemyWeapon.CreatePistol();
        SetHP();
        SetPoints();
        _source = gameObject.GetComponentInChildren<AudioSource>();
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == "Player") && (Time.time > _nextShot))
        {
            AttackPlayer();
        }
    }

    protected override void AttackPlayer()
    {
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, gameObject.transform.position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBullet>().BulletDamage = _enemyWeapon.Damage;
        _nextShot = Time.time + _enemyWeapon.FireRate;
        _source.Play();
    }

    protected override void SetHP()
    {
        EnemyHealth hp = gameObject.GetComponent<EnemyHealth>();
        hp.MaxHP = 50;
        hp.CurrentHP = hp.MaxHP;
    }

    void SetPoints()
    {
        gameObject.GetComponent<Points>().Amount = _points;
    }

}
