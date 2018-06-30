using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float _speed = 0.07f;
    short _bulletDamage;
    Vector2 _direction;

    public short BulletDamage
    {
        get { return _bulletDamage; }
        set { _bulletDamage = value; }
    }

    void Start()
    {
        Vector2 playerPos = GameObject.Find("Player").transform.position;
        Vector2 enemyPos = gameObject.GetComponentInParent<Transform>().position;
        _direction = playerPos - enemyPos;
        _direction.Normalize();
    }

    void FixedUpdate()
    {
        transform.Translate(_direction * _speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHealth playerHP = col.gameObject.GetComponent<PlayerHealth>();
            playerHP.DealDamageToPlayer(_bulletDamage);
        }
        Destroy(gameObject);
    }
}
