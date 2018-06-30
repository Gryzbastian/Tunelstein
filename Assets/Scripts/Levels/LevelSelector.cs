using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField]
    private Button[] _level1Buttons = new Button[3];
    [SerializeField]
    private Button[] _level2Buttons = new Button[3];
    [SerializeField]
    private Button[] _level3Buttons = new Button[3];

    public void ActivateUnlockedLevels()
    {
        Button[][] levelButtons = new Button[3][]
        {
            _level1Buttons,
            _level2Buttons,
            _level3Buttons
        };

        for(int i = 0; i < levelButtons.GetLength(0); i++)
        {
            LevelData level = Save.GetCurrentLevelSave(i);
            for (int j = 0; j < levelButtons[i].Length; j++)
            {
                if (level.LevelAccess != Access.Locked)
                {
                    if (level.LevelAccess == Access.Gold)
                        ActivateOneHitKill(levelButtons[i]);
                    else if (level.LevelAccess == Access.Silver)
                        ActivateTimeTrial(levelButtons[i]);
                    else
                        ActivateLevel(levelButtons[i]);
                }
            }
        }
    }

    private void ActivateLevel(Button[] levelButtons)
    {
        levelButtons[0].interactable = true;
    }

    private void ActivateTimeTrial(Button[] levelButtons)
    {
        levelButtons[0].interactable = true;
        levelButtons[1].interactable = true;
    }

    private void ActivateOneHitKill(Button[] levelButtons)
    {
        levelButtons[0].interactable = true;
        levelButtons[1].interactable = true;
        levelButtons[2].interactable = true;
    }
}
