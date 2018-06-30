using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class ProgressManager
{
    public static void UnlockNextLevel()
    {
        if(!NextLevelAlreadyUnlocked())
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
            int nextLevel = currentLevel + 1;
            if (nextLevel < Save.levelCount)
            {
                Save.GetCurrentLevelSave(nextLevel).LevelAccess = Access.Bronze;
            }
            UnlockTimeTrial();
        }       
    }

    private static void UnlockTimeTrial()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        Save.GetCurrentLevelSave(currentLevel).LevelAccess = Access.Silver;
    }

    public static void UnlockOneHitKill()
    {
        if(!OneHitKillAlreadyUnlocked())
        {
            int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
            Save.GetCurrentLevelSave(currentLevel).LevelAccess = Access.Gold;
        }       
    }

    private static bool NextLevelAlreadyUnlocked()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        int nextLevel = currentLevel + 1;
        if ((nextLevel < Save.levelCount) && (Save.GetCurrentLevelSave(nextLevel).LevelAccess >= Access.Bronze))
            return true;
        else
            return false;
    }

    private static bool OneHitKillAlreadyUnlocked()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex - 1;
        if (Save.GetCurrentLevelSave(currentLevel).LevelAccess == Access.Gold)
            return true;
        else
            return false;
    }   
}
