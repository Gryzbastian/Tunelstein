using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndOneHitKill : MonoBehaviour
{
    [SerializeField]
    private GameObject _endOneHitKillScreen;
    [SerializeField]
    private Text _endOneHitKillScoreText;

    void OnTriggerEnter2D(Collider2D other)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        if ((other.gameObject.name == "Player") && (PlayerScore.Score >= Requirements.GetPoints(currentLevel)))
        {
            PlayerControll.CanPause = false;
            Time.timeScale = 0;
            DisplayEndLevelScreen();
            SetScoreText();
            LoadSaveManager.SaveGame();
        }

        else if((other.gameObject.name == "Player") && (PlayerScore.Score < Requirements.GetPoints(currentLevel)))
        {
            gameObject.GetComponentInChildren<AudioSource>().Play();
        }
    }

    private void DisplayEndLevelScreen()
    {
        _endOneHitKillScreen.SetActive(true);
    }

    private void SetScoreText()
    {
        _endOneHitKillScoreText.text = "Wynik: " + PlayerScore.Score.ToString();
    }
}
