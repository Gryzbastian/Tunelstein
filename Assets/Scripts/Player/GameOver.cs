using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject _normalGameOverScreen;
    [SerializeField]
    private GameObject _timeTrialGameOverScreen;
    [SerializeField]
    private Text _normalScoreText;
    [SerializeField]
    private Text _timeTrialPlayerTime;
    [SerializeField]
    private Text _timeTrialRequiredTime;
    [SerializeField]
    private TimeTrialManager _ttm;

    public void DisplayGameOverScreen()
    {
        PlayerControll.CanPause = false;

        if (LevelMode.currentLevelMode == Mode.TimeTrial)
        {
            SetPlayerTime();
            SetRequiredTime();
            _timeTrialGameOverScreen.SetActive(true);
        }
            
        else
        {
            SetScoreText();
            _normalGameOverScreen.SetActive(true);
        }            
    }

    private void SetScoreText()
    {
        _normalScoreText.text = "Wynik: " + PlayerScore.Score.ToString();
    }

    private void SetPlayerTime()
    {
        string playerTimeString = TimeTrialManager.FormatTime(_ttm.PlayerTime);
        _timeTrialPlayerTime.text = "Twój czas: " + playerTimeString;
    }

    private void SetRequiredTime()
    {
        float requiredTime = Requirements.GetTime(SceneManager.GetActiveScene().buildIndex - 1);
        string requiredTimeString = TimeTrialManager.FormatTime(requiredTime);
        _timeTrialRequiredTime.text = "Czas wymagany: " + requiredTimeString;
    }
}
