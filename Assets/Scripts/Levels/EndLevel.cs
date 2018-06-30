using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject _endLevelScreen;
    [SerializeField]
    private Text _endLevelScoreText;

    void OnTriggerEnter2D(Collider2D other)
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        if ((other.gameObject.name == "Player") && (PlayerScore.Score >= Requirements.GetPoints(currentLevel)))
        {
            PlayerControll.CanPause = false;
            Time.timeScale = 0;
            DisplayEndLevelScreen();
            SetScoreText();
            ProgressManager.UnlockNextLevel();
            LoadSaveManager.SaveGame();
        }

        else if ((other.gameObject.name == "Player") && (PlayerScore.Score < Requirements.GetPoints(currentLevel)))
        {
            gameObject.GetComponentInChildren<AudioSource>().Play();
        }
    }

    private void DisplayEndLevelScreen()
    {
        _endLevelScreen.SetActive(true);
    }

    private void SetScoreText()
    {
        _endLevelScoreText.text = "Wynik: " + PlayerScore.Score.ToString();
    }
}
