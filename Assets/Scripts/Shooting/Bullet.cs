using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.01f;
    short _bulletDamage;
    Vector2 direction;

    public short BulletDamage
    {
        get { return _bulletDamage; }
        set { _bulletDamage = value; }
    }

    void Start()
    {
        Vector3 target = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 myPos = new Vector3(GameObject.Find("BulletSpawn").transform.position.x, GameObject.Find("BulletSpawn").transform.position.y, 0);
        direction = target - myPos;
        direction.Normalize();
    }

    void FixedUpdate()
    {             
        transform.Translate(direction * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            EnemyHealth enemyHP = col.gameObject.GetComponent<EnemyHealth>();
            enemyHP.DealDamageToEnemy(_bulletDamage);
        }
        Destroy(gameObject);
    }
}
