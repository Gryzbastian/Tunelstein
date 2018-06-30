using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    string _weaponName;
    int _weaponDamage;
    short _weaponAmmoCap;
    short _weaponAmmoLeft;
    short _weaponMagCap;
    short _weaponMag;
    float _weaponFireRate;
    float _weaponReloadTime;
    byte _weaponIdentifier;
    AudioClip _weaponSound;
    Sprite _weaponSprite;

    public string Name
    {
        get { return _weaponName; }
    }

    public short Damage
    {
        get { return (short)_weaponDamage; }
    }

    public short AmmoCap
    {
        get { return _weaponAmmoCap; }
    }

    public short AmmoLeft
    {
        get { return _weaponAmmoLeft; }
        set { _weaponAmmoLeft = value; }
    }

    public short MagCap
    {
        get { return _weaponMagCap; }
    }

    public short Mag
    {
        get { return _weaponMag; }
        set { _weaponMag = value; }
    }

    public float FireRate
    {
        get { return _weaponFireRate; }
    }

    public float ReloadTime
    {
        get { return _weaponReloadTime; }
    }

    public byte Identifier
    {
        get { return _weaponIdentifier; }
        set { _weaponIdentifier = value; }
    }

    public AudioClip Sound
    {
        get { return _weaponSound; }
    }

    public Sprite Sprite
    {
        get { return _weaponSprite; }
    }    

    public static Weapon CreatePistol()
    {
        Weapon pistol = new Weapon();
        pistol._weaponName = "Pistolet";
        pistol._weaponDamage = 10;
        pistol._weaponAmmoCap = 300;
        pistol._weaponAmmoLeft = 48;
        pistol._weaponMagCap = 12;
        pistol._weaponMag = pistol._weaponMagCap;
        pistol._weaponFireRate = 0.5f;
        pistol._weaponReloadTime = 2.5f;
        pistol._weaponIdentifier = 0;
        pistol._weaponSound = GameObject.Find("GunSounds").GetComponent<WeaponSounds>().weaponSounds[pistol._weaponIdentifier];
        pistol._weaponSprite = GameObject.Find("GunSprites").GetComponent<WeaponSprites>().weaponSprites[pistol._weaponIdentifier];
        return pistol;
    }

    public static Weapon CreateSMG()
    {
        Weapon smg = new Weapon();
        smg._weaponName = "Pistolet Maszynowy";
        smg._weaponDamage = 5;
        smg._weaponAmmoCap = 300;
        smg._weaponAmmoLeft = 100;
        smg._weaponMagCap = 50;
        smg._weaponMag = smg._weaponMagCap;
        smg._weaponFireRate = 0.15f;
        smg._weaponReloadTime = 2.5f;
        smg._weaponIdentifier = 1;
        smg._weaponSound = GameObject.Find("GunSounds").GetComponent<WeaponSounds>().weaponSounds[smg._weaponIdentifier];
        smg._weaponSprite = GameObject.Find("GunSprites").GetComponent<WeaponSprites>().weaponSprites[smg._weaponIdentifier];
        return smg;
    }

    public static Weapon CreateShotgun()
    {
        Weapon shotgun = new Weapon();
        shotgun._weaponName = "Strzelba";
        shotgun._weaponDamage = 50;
        shotgun._weaponAmmoCap = 60;
        shotgun._weaponAmmoLeft = 24;
        shotgun._weaponMagCap = 6;
        shotgun._weaponMag = shotgun._weaponMagCap;
        shotgun._weaponFireRate = 1.3f;
        shotgun._weaponReloadTime = 3.0f;
        shotgun._weaponIdentifier = 2;
        shotgun._weaponSound = GameObject.Find("GunSounds").GetComponent<WeaponSounds>().weaponSounds[shotgun._weaponIdentifier];
        shotgun._weaponSprite = GameObject.Find("GunSprites").GetComponent<WeaponSprites>().weaponSprites[shotgun._weaponIdentifier];
        return shotgun;
    }

    public static Weapon CreateRifle()
    {
        Weapon rifle = new Weapon();
        rifle._weaponName = "Karabin Szturmowy";
        rifle._weaponDamage = 15;
        rifle._weaponAmmoCap = 200;
        rifle._weaponAmmoLeft = 90;
        rifle._weaponMagCap = 30;
        rifle._weaponMag = rifle._weaponMagCap;
        rifle._weaponFireRate = 0.2f;
        rifle._weaponReloadTime = 2.0f;
        rifle._weaponIdentifier = 3;
        rifle._weaponSound = GameObject.Find("GunSounds").GetComponent<WeaponSounds>().weaponSounds[rifle._weaponIdentifier];
        rifle._weaponSprite = GameObject.Find("GunSprites").GetComponent<WeaponSprites>().weaponSprites[rifle._weaponIdentifier];
        return rifle;
    }
}
