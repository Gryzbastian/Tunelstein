using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiflePickup : MonoBehaviour
{
    byte _pickupId = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            PlayerBackpack.OnWeaponPickup(_pickupId);
            Destroy(gameObject);
        }
    }
}
