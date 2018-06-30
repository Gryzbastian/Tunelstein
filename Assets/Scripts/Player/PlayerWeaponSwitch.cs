using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSwitch : MonoBehaviour
{
    private static Weapon _currentWeapon;
    private SpriteRenderer _weaponRenderer;
    void Start ()
    {
        _currentWeapon = PlayerBackpack.currentWeapon;
        _weaponRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {     
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerBackpack.NextWeapon();
            ChangeWeaponSprite();
        }               
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerBackpack.PreviousWeapon();
            ChangeWeaponSprite();
        }           
    }
    
    private void ChangeWeaponSprite()
    {
        _weaponRenderer.sprite = _currentWeapon.Sprite;
    }

    public static void SetCurrentWeapon()
    {
        _currentWeapon = PlayerBackpack.currentWeapon;
    }
}
