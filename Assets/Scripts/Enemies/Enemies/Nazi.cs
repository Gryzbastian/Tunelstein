using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nazi : Enemy
{
    float _nextShot = 0.0f;
    int _points = 100;
    EnemyAI _naziAI;
    bool _playerDetected;
    Animator ani;
    AudioSource _source;
    [SerializeField]
    AudioClip _mgsFoundSound;
    [SerializeField]
    GameObject _mgsExclamationMark;

	void Start ()
    {
        ani = gameObject.GetComponent<Animator>();
        ani.enabled = false;
        _enemyWeapon = EnemyWeapon.CreatePistol();
        SetHP();
        SetPoints();
        _naziAI = gameObject.GetComponent<EnemyAI>();
        _playerDetected = false;
        _source = gameObject.GetComponentInChildren<AudioSource>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_playerDetected && other.gameObject.name == "Player")
        {
            _naziAI.CastRays(other.gameObject.transform.position);
            if (_naziAI.CanPlayerBeSeen())
            {
                gameObject.GetComponentInChildren<AudioSource>().PlayOneShot(_mgsFoundSound);
                _playerDetected = true;
                ShowExclamationMark();
            }                
        }            
    }

    protected override void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            _naziAI.CastRays(other.gameObject.transform.position);
            if (_naziAI.CanPlayerBeSeen())
            {
                ShowExclamationMark();
                _naziAI.MoveTowardsPlayer(other.transform.position);
                ani.enabled = true;
                if (Time.time > _nextShot)
                {
                    AttackPlayer();
                    _source.Play();
                }                                 
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            ani.enabled = false;
            HideExclamationMark();
        }
    }

    protected override void AttackPlayer()
    {
        GameObject enemyBullet = Instantiate(enemyBulletPrefab, gameObject.transform.position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBullet>().BulletDamage = _enemyWeapon.Damage;
        _nextShot = Time.time + _enemyWeapon.FireRate;
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

    void ShowExclamationMark()
    {
        _mgsExclamationMark.SetActive(true);
    }

    void HideExclamationMark()
    {
        _mgsExclamationMark.SetActive(false);
    }
}
