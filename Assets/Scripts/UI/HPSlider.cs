using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPSlider : MonoBehaviour
{
    Slider _HPSlider;

	void Awake()
    {
        _HPSlider = gameObject.GetComponent<Slider>();
	}

    public void UpdateSlider()
    {
        _HPSlider.value = PlayerHealth.CurrentHP;
    }
}
