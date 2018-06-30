using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackpack : MonoBehaviour
{
    public static Weapon currentWeapon;
    static List<Weapon> _backpack;
    static int _currentWeaponIndex = 0;
    static int _existingWeaponIndex;   

    void Awake()
    {
        _currentWeaponIndex = 0;
        _backpack = new List<Weapon>();
        SetDefaultWeapon();
    }

    public void SetDefaultWeapon()
    {
        _backpack.Add(Weapon.CreatePistol());
        currentWeapon = _backpack[0];
        Shooting.SetCurrentWeapon();
        PlayerWeaponSwitch.SetCurrentWeapon();
        HUD.SetCurrentWeapon();
    }

    public static void OnWeaponPickup(byte id)
    {
        if (id == currentWeapon.Identifier)
            AddAmmoToCurrentWeapon();
        else if (SearchBackpack(id))
            AddAmmoToBackpackWeapon();
        else
            AddWeaponToBackpack(id);
    }

    private static void AddAmmoToCurrentWeapon()
    {
        short tempAmmo = (short)(currentWeapon.AmmoLeft + currentWeapon.MagCap);
        if (tempAmmo <= currentWeapon.AmmoCap)
            currentWeapon.AmmoLeft = tempAmmo;       
        else
        {
            short diff = (short)(currentWeapon.AmmoCap - currentWeapon.AmmoLeft);
            currentWeapon.AmmoLeft += diff;
        }
        HUD.UpdateAmmoDisplay();
    }

    private static void AddAmmoToBackpackWeapon()
    {
        Weapon existingWeapon = _backpack[_existingWeaponIndex];
        short tempAmmo = (short)(existingWeapon.AmmoLeft + existingWeapon.MagCap);
        if (tempAmmo <= existingWeapon.AmmoCap)
            existingWeapon.AmmoLeft = tempAmmo;
        else
        {
            short diff = (short)(existingWeapon.AmmoCap - existingWeapon.AmmoLeft);
            existingWeapon.AmmoLeft += diff;
        }           
    }

    private static void AddWeaponToBackpack(byte id)
    {
        switch (id)
        {
            case 1:
                _backpack.Add(Weapon.CreateSMG());
                break;
            case 2:
                _backpack.Add(Weapon.CreateShotgun());
                break;
            case 3:
                _backpack.Add(Weapon.CreateRifle());
                break;
            default:
                throw new System.Exception("Undefined weapon collected!");
        }
    }

    private static bool SearchBackpack(byte id)
    {
        bool isInBackpack = false;
        for (int i = 0; i < _backpack.Count; i++)
        {
            if (_backpack[i] != null)
            {
                if (_backpack[i].Identifier == id)
                {
                    isInBackpack = true;
                    _existingWeaponIndex = i;
                    break;
                }
            }
        }
        return isInBackpack;
    }

    public static void NextWeapon()
    {
        int i = _currentWeaponIndex + 1;
        int lastPossibleIndex = _backpack.Count;
        if (i <= lastPossibleIndex - 1)
        {
            if (_backpack[i] != null)
            {
                currentWeapon = _backpack[i];
                Shooting.SetCurrentWeapon();
                PlayerWeaponSwitch.SetCurrentWeapon();
                HUD.SetCurrentWeapon();
                HUD.UpdateWeaponDisplay();
                _currentWeaponIndex = i;
            }
        }
    }

    public static void PreviousWeapon()
    {
        int i = _currentWeaponIndex - 1;
        if (i >= 0)
        {
            currentWeapon = _backpack[i];
            Shooting.SetCurrentWeapon();
            PlayerWeaponSwitch.SetCurrentWeapon();
            HUD.SetCurrentWeapon();
            HUD.UpdateWeaponDisplay();
            _currentWeaponIndex = i;
        }
    }
}
