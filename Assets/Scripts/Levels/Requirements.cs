using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requirements : MonoBehaviour
{
    static int[] _pointRequirements = new int[Save.levelCount];
    static float[] _timeRequirements = new float[Save.levelCount];
    static bool _gameLoaded;

    void Awake()
    {
        if(!_gameLoaded)
        {                       
            SetPointRequirements();
            SetTimeRequirements();
            _gameLoaded = true;
        }       
    }

    public static int GetPoints(int currentLevel)
    {
        return _pointRequirements[currentLevel];
    }

    public static float GetTime(int currentLevel)
    {
        return _timeRequirements[currentLevel];
    }

    void SetPointRequirements()
    {
        _pointRequirements[0] = 350;
        _pointRequirements[1] = 700;
        _pointRequirements[2] = 3500;
    }

    void SetTimeRequirements()
    {
        _timeRequirements[0] = 20.0f;
        _timeRequirements[1] = 50.0f;
        _timeRequirements[2] = 230.0f;
    }
}
