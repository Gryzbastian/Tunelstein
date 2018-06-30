using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange: MonoBehaviour
{ 
    public void LoadByIndex(int SceneIndex)
    {
        SceneManager.LoadSceneAsync(SceneIndex);
        Time.timeScale = 1;
    }

    public void LoadNextLevel()
    {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadSceneAsync(nextLevel);
        Time.timeScale = 1;
    }
}
