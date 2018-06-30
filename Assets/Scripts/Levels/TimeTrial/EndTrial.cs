using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndTrial : MonoBehaviour
{
    [SerializeField]
    private GameObject _endScreen;
    [SerializeField]
    private Text _endScreenVictoryText;
    [SerializeField]
    private GameObject _endScreenNewRecordText;
    [SerializeField]
    private Text _endScreenTimeRequirement;    
    [SerializeField]
    private Text _endScreenPlayerTime;
    [SerializeField]
    private Text[] _scoreboardTimes = new Text[Save.maxRecords];
    [SerializeField]
    private TimeTrialManager _ttm;
    [SerializeField]
    private RecordsManager _rm;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            _ttm.StopTrial();
            PlayerControll.CanPause = false;
            DisplayEndTrialScreen();

            if (_ttm.EvaluateResult())
            {
                SetWinText();
                ProgressManager.UnlockOneHitKill();
            }
            else
            {
                SetLossText();
            }

            SetPlayerTime();

            if (_rm.EvaluateRecords())
            {
                DisplayNewRecordText();
                UpdateRecordsBoard();
            }

            LoadSaveManager.SaveGame();
        }        
    }

    public void DisplayEndTrialScreen()
    {
        _endScreen.SetActive(true);
    }

    public void DisplayNewRecordText()
    {
        _endScreenNewRecordText.SetActive(true);
    }

    public void SetRequiredTime()
    {
        float requiredTime = Requirements.GetTime(SceneManager.GetActiveScene().buildIndex - 1);
        string requiredTimeString = TimeTrialManager.FormatTime(requiredTime);
        _endScreenTimeRequirement.GetComponent<Text>().text = "Czas wymagany: " + requiredTimeString;
    }

    public void SetPlayerTime()
    {
        string playerTimeString = TimeTrialManager.FormatTime(_ttm.PlayerTime);
        _endScreenPlayerTime.text = "Twój czas: " + playerTimeString;
    }

    public void SetWinText()
    {
        _endScreenVictoryText.text = "Wygrałeś!";
    }

    public void SetLossText()
    {
        _endScreenVictoryText.text = "Przegrałeś!";
    }

    public void UpdateRecordsBoard()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        RecordsData savedRecords = Save.GetCurrentLevelRecords(currentLevel);
        float[] playerRecords = savedRecords.GetRecords();

        for (int i = 0; i < playerRecords.Length; i++)
        {
            _scoreboardTimes[i].text = TimeTrialManager.FormatTime(playerRecords[i]);
        }
    }
}
