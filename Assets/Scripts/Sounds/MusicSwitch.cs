using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSwitch: MonoBehaviour
{
    public AudioClip[] listaUtworow = new AudioClip[4];
    public AudioSource Zrodlo;

    void Start()
    {
        Zrodlo.loop = true;
        Zrodlo.clip = listaUtworow[SceneManager.GetActiveScene().buildIndex];
        Zrodlo.Play();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Zrodlo.clip = listaUtworow[SceneManager.GetActiveScene().buildIndex];
        Zrodlo.loop = true;
        Zrodlo.Play();
    }
}