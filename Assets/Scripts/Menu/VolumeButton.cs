using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{
    public Slider slider;

    public void VolumeDown()
    {
        if (slider.value > 0)
            slider.value = slider.value - 0.1f;
    }

    public void VolumeUp()
    {
        if (slider.value < 1)
            slider.value = slider.value + 0.1f;
    }
}
