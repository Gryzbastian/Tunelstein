using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSliderControlls : MonoBehaviour
{
    public Slider musicSlider;
    private GameObject Music;

    void Start()
    {
        Music = GameObject.Find("Music");
        musicSlider.value = Music.GetComponent<AudioSource>().volume;
        musicSlider.onValueChanged.AddListener(delegate { ValueChangeMusic(); });
    }
  
    public void ValueChangeMusic()
    {
        Music.GetComponent<AudioSource>().volume = musicSlider.value;
    }
}
