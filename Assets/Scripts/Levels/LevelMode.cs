using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMode : MonoBehaviour
{
    public static Mode currentLevelMode;
    
    public void Normal()
    {
        currentLevelMode = Mode.Normal;
    }

    public void TimeTrial()
    {
        currentLevelMode = Mode.TimeTrial;
    }

    public void OneHitKill()
    {
        currentLevelMode = Mode.OneHitKill;
    }
}
