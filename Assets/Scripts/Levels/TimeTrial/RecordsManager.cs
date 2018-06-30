using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecordsManager : MonoBehaviour
{
    private static int _newRecordIndex;
    private bool _newRecord;
    [SerializeField]
    private TimeTrialManager _timeTrialManager;     

    public static int NewRecordIndex
    {
        get { return _newRecordIndex; }
        set { _newRecordIndex = value; }
    }

    public bool EvaluateRecords()
    {
        float finishTime = _timeTrialManager.PlayerTime;
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        RecordsData records = Save.GetCurrentLevelRecords(currentLevel);

        _newRecord = false;

        if (records.IsNewRecord(finishTime))
        {
            records.SetNewRecord(finishTime);
            _newRecord = true;
        }
        return _newRecord;
    }
}
