using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    Access _levelAccess;

    public Access LevelAccess
    {
        get { return _levelAccess; }
        set { _levelAccess = value; }
    }

    public static LevelData[] GenerateDefaultLevelData()
    {
        LevelData[] defaultData = new LevelData[Save.levelCount];
        for(int i = 0; i < defaultData.Length; i++)
        {
            defaultData[i] = new LevelData();
        }
        defaultData[0]._levelAccess = Access.Bronze;
        return defaultData;
    }
}
