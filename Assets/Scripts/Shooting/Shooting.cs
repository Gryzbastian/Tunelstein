using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GameObject bulletSpawn;
    public GameObject bullet;   
    static Weapon _currentWeapon;
    static float _nextFire = 0.0f;
    static float _reloadTimer = 0.0f;
    AudioSource _source;
    AudioClip _reloadSound;

    void Start()
    {
        _source = gameObject.GetComponent<AudioSource>();
        _reloadSound = GameObject.Find("GunSounds").GetComponent<WeaponSounds>().reloadSound;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Reload(); 

        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && (Time.time > _nextFire) && (Time.time > _reloadTimer))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_currentWeapon.Mag > 0)
        {
            Fire();
            PlayGunSound();
        }
        else
        {
            Reload();
        }
    }

    private void Fire()
    {
        SpawnPlayerBullet();        
        _nextFire = Time.time + _currentWeapon.FireRate;
        _currentWeapon.Mag--;
        HUD.UpdateAmmoDisplay();
    }

    private void SpawnPlayerBullet()
    {
        Vector3 bulletSpawnPos = new Vector3(bulletSpawn.transform.position.x, bulletSpawn.transform.position.y, 0);
        GameObject friendlyBullet = Instantiate(bullet, bulletSpawnPos, Quaternion.identity);
        friendlyBullet.GetComponent<Bullet>().BulletDamage = _currentWeapon.Damage;
    }

    private void PlayGunSound()
    {
        _source.clip = _currentWeapon.Sound;
        _source.Play();
    }

    private void PlayReloadSound()
    {
        _source.clip = _reloadSound;
        _source.Play();
    }

    private void Reload()
    {
        if (_currentWeapon.Mag == _currentWeapon.MagCap)
            return;

        else if (_currentWeapon.AmmoLeft != 0 && _currentWeapon.AmmoLeft >= _currentWeapon.MagCap)
        {
            short diff = (short)(_currentWeapon.MagCap - _currentWeapon.Mag);
            _currentWeapon.Mag = _currentWeapon.MagCap;
            _currentWeapon.AmmoLeft = (short)(_currentWeapon.AmmoLeft - diff);
            _reloadTimer = Time.time + _currentWeapon.ReloadTime;
            HUD.UpdateAmmoDisplay();
            PlayReloadSound();
        }

        else if (_currentWeapon.AmmoLeft != 0 && _currentWeapon.AmmoLeft < _currentWeapon.MagCap)
        {
            short diff = (short)(_currentWeapon.MagCap - _currentWeapon.Mag);
            if (diff < _currentWeapon.AmmoLeft)
            {
                _currentWeapon.Mag += diff;
                _currentWeapon.AmmoLeft -= diff;
            }
            else
            {
                _currentWeapon.Mag += _currentWeapon.AmmoLeft;
                _currentWeapon.AmmoLeft = 0;
            }            
            _reloadTimer = Time.time + _currentWeapon.ReloadTime;
            HUD.UpdateAmmoDisplay();
            PlayReloadSound();
        }
    }

    public static void SetCurrentWeapon()
    {
        _currentWeapon = PlayerBackpack.currentWeapon;
        _nextFire = 0;
        _reloadTimer = 0;        
    }
}
