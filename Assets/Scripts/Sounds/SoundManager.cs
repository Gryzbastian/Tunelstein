using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider musicSlider;
    public Slider effectsSlider;
    public static string soundFilePath = "SoundTest";
    private static bool _loaded;

	void Start()
    {
        if(!_loaded)
        {
            LoadSoundSettings();
            _loaded = true;
        }
        else
        {
            SetSliders();
            SetVolumes();
        }               
	}

    public void SaveSettings()
    {
        SoundSettings.musicVolume = musicSlider.value;
        SoundSettings.effectsVolume = effectsSlider.value;
    }

    public static void SaveSettingsToFile()
    {
        FileStream fs = new FileStream(soundFilePath, FileMode.Truncate, FileAccess.Write, FileShare.None);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(SoundSettings.musicVolume.ToString());
        sw.WriteLine(SoundSettings.effectsVolume.ToString());
        sw.Flush();
        sw.Close();
        fs.Close();
    }

    private void LoadSoundSettings()
    {
        if (File.Exists(soundFilePath))
        {
            LoadVolumeSettings();
            SetSliders();
            SetVolumes();
            SaveSettings();
        }
        else
        {
            CreateDefaultFile();
        }
    }
    
    private void CreateDefaultFile()
    {
        FileStream fs = new FileStream(soundFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(SoundSettings.musicVolume.ToString());
        sw.WriteLine(SoundSettings.effectsVolume.ToString());
        sw.Flush();
        sw.Close();
        fs.Close();
        fs.Close();
    }

    private void LoadVolumeSettings()
    {
        FileStream fs = new FileStream(soundFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
        StreamReader sr = new StreamReader(fs);
        SoundSettings.musicVolume = float.Parse(sr.ReadLine());
        SoundSettings.effectsVolume = float.Parse(sr.ReadLine());
        sr.Close();
        fs.Close();
    }

    protected void SetSliders()
    {
        musicSlider.value = SoundSettings.musicVolume;
        effectsSlider.value = SoundSettings.effectsVolume;
    }

    protected void SetVolumes()
    {
        GameObject[] effectsObjects = GameObject.FindGameObjectsWithTag("Efekty");
        AudioSource[] effectsSources = new AudioSource[effectsObjects.Length];
        float volume = SoundSettings.effectsVolume;
        for (int i = 0; i < effectsSources.Length; i++)
        {
            effectsSources[i] = effectsObjects[i].GetComponent<AudioSource>();
            effectsSources[i].volume = volume; 
        } 
    }
}
