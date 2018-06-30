using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class LoadSaveManager : MonoBehaviour
{      
    static IFormatter _formatter = new BinaryFormatter();
    [SerializeField]
    private LevelSelector _levelSelector;
    [SerializeField]
    private RecordsLoader _recordsLoader;

    void Awake()
    {
        LoadGame();
        _levelSelector.ActivateUnlockedLevels();
        _recordsLoader.LoadPlayerRecords();
	}

    public static void SaveGame()
    {
        FileStream levelStream = new FileStream(Save.saveFilePath, FileMode.Truncate, FileAccess.Write, FileShare.None);
        FileStream recordsStream = new FileStream(Save.recordsFilePath, FileMode.Truncate, FileAccess.Write, FileShare.None);
        _formatter.Serialize(levelStream, Save.GetCurrentSave());
        _formatter.Serialize(recordsStream, Save.GetCurrentRecords());
        recordsStream.Flush();
        recordsStream.Close();
        levelStream.Flush();
        levelStream.Close();
    }

    void LoadGame()
    {
        if(!Directory.Exists(Save.dataDirectory))
        {
            Directory.CreateDirectory(Save.dataDirectory);
        }
        if(!File.Exists(Save.saveFilePath))
        {
            GenerateDefaultSaveFile();            
        }
        if(!File.Exists(Save.recordsFilePath))
        {
            GenerateDefaultRecordsFile();
        }
        LoadDataFromFile();
    }

    void LoadDataFromFile()
    {       
        FileStream levelStream = new FileStream(Save.saveFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
        FileStream recordsStream = new FileStream(Save.recordsFilePath, FileMode.Open, FileAccess.Read, FileShare.None);

        Save.SetSave((LevelData[])_formatter.Deserialize(levelStream));
        Save.SetRecords((RecordsData[])_formatter.Deserialize(recordsStream));

        recordsStream.Flush();
        recordsStream.Close();
        levelStream.Flush();
        levelStream.Close();
    }

    void GenerateDefaultSaveFile()
    {
        FileStream fs = new FileStream(Save.saveFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
        _formatter.Serialize(fs, Save.GetCurrentSave());
        fs.Flush();
        fs.Close();
    }

    void GenerateDefaultRecordsFile()
    {
        FileStream fs = new FileStream(Save.recordsFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
        _formatter.Serialize(fs, Save.GetCurrentRecords());
        fs.Flush();
        fs.Close();
    }
}
