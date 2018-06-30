using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    static int _score;
    static bool _metRequirements;

    public static int Score
    {
        get { return _score; }
    }

    void Start()
    {
        _score = 0;
        _metRequirements = false;
    }

    public static void AddPoints(int points)
    {
        _score += points;
        if (!_metRequirements)
        {
            CheckPointsRequirement();
        }      
    }

    private static void CheckPointsRequirement()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        if (_score >= Requirements.GetPoints(currentLevel))
        {
            _metRequirements = true;
            HUD.UpdateScoreColor();
        }
    }
}
