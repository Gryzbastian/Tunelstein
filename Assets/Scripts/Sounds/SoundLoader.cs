using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundLoader : SoundManager
{   
	void Start()
    {
        SetSliders();
        SetVolumes();
	}

    public void UpdateVolumes()
    {
        SaveSettings();
        SetVolumes();
    }
}
