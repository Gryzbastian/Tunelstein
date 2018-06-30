using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveObjectsOnSceneChange : MonoBehaviour
{
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Muzyka");
        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}