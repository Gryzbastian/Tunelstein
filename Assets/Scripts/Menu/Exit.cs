﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public void exit()
    {
        SoundManager.SaveSettingsToFile();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else    
        Application.Quit();
#endif
    }
}
