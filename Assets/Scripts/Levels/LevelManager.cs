using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private TimeTrialManager _ttManager;
    [SerializeField]
    private OneHitKillManager _ohkManager;
    [SerializeField]
    private GameObject _normalLevelExit;
    [SerializeField]
    private GameObject _timeTrialLevelExit;
    [SerializeField]
    private GameObject _oneHitKillLevelExit;

	void Awake()
    {
        SetChallenge();
	}

    void SetChallenge()
    {
        if (LevelMode.currentLevelMode == Mode.TimeTrial)
        {
            _normalLevelExit.SetActive(false);
            _timeTrialLevelExit.SetActive(true);
            _ttManager.StartTrial();
        }
        else if (LevelMode.currentLevelMode == Mode.OneHitKill)
        {
            _normalLevelExit.SetActive(false);
            _oneHitKillLevelExit.SetActive(true);
            _ohkManager.StartOneHitKill();
        }
    }
}
