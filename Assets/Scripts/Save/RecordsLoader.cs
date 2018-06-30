using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsLoader : MonoBehaviour
{
    [SerializeField]
    private Text[] _level1Scoreboard = new Text[Save.maxRecords];
    [SerializeField]
    private Text[] _level2Scoreboard = new Text[Save.maxRecords];
    [SerializeField]
    private Text[] _level3Scoreboard = new Text[Save.maxRecords];

    public void LoadPlayerRecords()
    {
        Text[][] _levelScoreBoards = new Text[3][]
        {
            _level1Scoreboard,
            _level2Scoreboard,
            _level3Scoreboard
        };

        for (int i = 0; i < _levelScoreBoards.GetLength(0); i++)
        {
            RecordsData recordsData = Save.GetCurrentLevelRecords(i);
            float[] records = recordsData.GetRecords();
            for (int j = 0; j < records.Length; j++)
            {
                _levelScoreBoards[i][j].text = TimeTrialManager.FormatTime(records[j]);
            }
        }
    }
}
