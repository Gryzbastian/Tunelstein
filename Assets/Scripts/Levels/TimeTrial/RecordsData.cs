using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecordsData
{
    float[] _playerTimes;

    public static RecordsData[] GenerateDefaultPlayerTimes()
    {
        RecordsData[] defaultTimes = new RecordsData[Save.levelCount];
        for(int i = 0; i < defaultTimes.Length; i++)
        {
            defaultTimes[i] = new RecordsData();
            defaultTimes[i]._playerTimes = new float[Save.maxRecords];
            for(int j = 0; j < Save.maxRecords; j++)
            {
                defaultTimes[i]._playerTimes[j] = 36000.0f;
            }
        }
        return defaultTimes;
    }

    public float[] GetRecords()
    {
        return _playerTimes;
    }

    public void SetNewRecord(float newRecord)
    {
        int lastIndex = _playerTimes.Length - 1;
        int newRecordIndex = RecordsManager.NewRecordIndex;
        if (newRecordIndex != lastIndex)
        {
            ShiftTimes(lastIndex, newRecordIndex);
        }
        _playerTimes[newRecordIndex] = newRecord;
    }

    public bool IsNewRecord(float newTime)
    {
        for(int i = 0; i < _playerTimes.Length; i++)
        {
            if(newTime < _playerTimes[i])
            {
                RecordsManager.NewRecordIndex = i;
                return true;
            }                
        }
        return false;
    }

    private void ShiftTimes(int bottom, int top)
    {
        for(int i = bottom; i > top; i--)
        {
            _playerTimes[i] = _playerTimes[i - 1];
        }
    }
}
