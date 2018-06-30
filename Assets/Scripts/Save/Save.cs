using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save
{
    public static readonly int levelCount = 3;
    public static readonly int maxRecords = 5;
    public static readonly string dataDirectory = "Saves";
    public static readonly string saveFilePath = "Saves/save.sav";
    public static readonly string recordsFilePath = "Saves/records.sav";
    static LevelData[] _save = LevelData.GenerateDefaultLevelData();
    static RecordsData[] _playerRecords = RecordsData.GenerateDefaultPlayerTimes();

    public static LevelData[] GetCurrentSave()
    {
        return _save;
    }

    public static LevelData GetCurrentLevelSave(int currentLevel)
    {
        return _save[currentLevel];
    }

    public static void SetSave(LevelData[] newData)
    {
        _save = newData;
    }

    public static RecordsData[] GetCurrentRecords()
    {
        return _playerRecords;
    }

    public static RecordsData GetCurrentLevelRecords(int currentLevel)
    {
        return _playerRecords[currentLevel];
    }

    public static void SetRecords(RecordsData[] newData)
    {
        _playerRecords = newData;
    }
}
