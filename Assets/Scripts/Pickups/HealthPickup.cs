using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    short _hpValue = 50;

	void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && (PlayerHealth.CurrentHP < PlayerHealth.MaxHP))
        {
            PlayerHealth playerHP = other.gameObject.GetComponent<PlayerHealth>();
            playerHP.HealPlayer(_hpValue);
            Destroy(gameObject);
        }
    }
}
