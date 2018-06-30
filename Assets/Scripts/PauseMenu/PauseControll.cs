using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseControll : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject MainMenu;
    public GameObject SliderMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerControll.CanPause)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }
            else if (MainMenu.activeSelf)
            {
                Time.timeScale = 1;
                PauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                MainMenu.SetActive(true);
                SliderMenu.SetActive(false);
                PauseMenu.SetActive(false);
            }
        }
    }

    public void UnPause()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
}
