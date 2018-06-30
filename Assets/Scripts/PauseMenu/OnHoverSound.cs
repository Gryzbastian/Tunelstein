using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class OnHoverSound : EventTrigger
{
    private AudioSource HoverSound;

    void Start()
    {
        HoverSound = GameObject.Find("OnHoverSound").GetComponent<AudioSource>();
    }

    public override void OnPointerEnter(PointerEventData data)
    {
        HoverSound.Play();
    }

    public override void OnSelect(BaseEventData data)
    {
        HoverSound.Play();
    }
}

