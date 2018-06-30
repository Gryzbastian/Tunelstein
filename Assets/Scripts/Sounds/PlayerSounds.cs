using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip playerDamaged;

    public void PlayGruntSound()
    {
        AudioSource auS = gameObject.GetComponentInChildren<AudioSource>();
        auS.clip = playerDamaged;
        auS.Play();
    }
}
