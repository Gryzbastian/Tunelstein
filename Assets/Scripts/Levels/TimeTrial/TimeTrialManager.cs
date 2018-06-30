using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeTrialManager : MonoBehaviour
{
    [SerializeField]
    private RecordsManager _recordsManager;
    [SerializeField]
    private EndTrial _endTrial;
    float _playerTime;
    bool _levelCompleted;

    public float PlayerTime
    {
        get { return _playerTime; }
    }

    void Update()
    {
        if(!_levelCompleted)
        {
            UpdateTimer();
            HUD.UpdateTimeDisplay(FormatTime(_playerTime));
        }       
    }

	public void StartTrial()
    {
        _endTrial.SetRequiredTime();
        gameObject.SetActive(true);
    } 

    public bool EvaluateResult()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        if (_playerTime <= Requirements.GetTime(currentLevel))
            return true;
        else
            return false;
    }

    public void StopTrial()
    {
        Time.timeScale = 0;
        _levelCompleted = true;
    }

    private void UpdateTimer()
    {
        _playerTime += Time.deltaTime;
    }    

    public static string FormatTime(float time)
    {
        string timeString;

        if (time >= 60)
        {
            int minutes = (int)time / 60;
            float seconds = time - (60 * minutes);
            timeString = minutes.ToString() + ":" + seconds.ToString("00.00");
        }
        else
        {
            timeString = time.ToString("0:00.00");
        }

        return timeString;
    }
}
