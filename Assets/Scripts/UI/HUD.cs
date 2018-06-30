using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static Weapon _currentWeapon;
    static Text[] _texts = new Text[5];
    static Text _HPBarDisplay;
    static Text _currentWeaponDisplay;
    static Text _ammoDisplay;
    static Text _pointsDisplay;
    static Text _timeDisplay; 
    static HPSlider _hpBar;

    void Start()
    {
        _texts = GetComponentsInChildren<Text>();
        _HPBarDisplay = _texts[0];
        _currentWeaponDisplay = _texts[1];
        _ammoDisplay = _texts[2];
        _pointsDisplay = _texts[3];
        _timeDisplay = _texts[4];
        _timeDisplay.gameObject.SetActive(false);
        _hpBar = gameObject.GetComponentInChildren<HPSlider>();
        SetPlayerHPDisplay();
        UpdateWeaponDisplay();
        SetDefaultPoints();
        SetChallengeDisplay();
    }

    public static void SetPlayerHPDisplay()
    {
        _HPBarDisplay.text = PlayerHealth.MaxHP.ToString();
    }

    public static void SetDefaultPoints()
    {
        _pointsDisplay.text = "0";
    }

    private static void SetChallengeDisplay()
    {
        if (LevelMode.currentLevelMode == Mode.TimeTrial)
            TimerDisplayOn();
        else if (LevelMode.currentLevelMode == Mode.OneHitKill)
            OneHitKillDisplayOn();
    }

    public static void TimerDisplayOn()
    {
        _pointsDisplay.gameObject.SetActive(false);
        _timeDisplay.gameObject.SetActive(true);
    }

    public static void OneHitKillDisplayOn()
    {
        _HPBarDisplay.gameObject.SetActive(false);
        _hpBar.gameObject.SetActive(false);
    }

    public static void UpdateScore()
    {
        _pointsDisplay.text = PlayerScore.Score.ToString();
    }

    public static void UpdateScoreColor()
    {
        _pointsDisplay.color = Color.green;
    }

    public static void UpdateHPDisplay()
    {
        _HPBarDisplay.text = PlayerHealth.CurrentHP.ToString();       
        _hpBar.UpdateSlider();
    }

    public static void UpdateAmmoDisplay()
    {
        _ammoDisplay.text = _currentWeapon.Mag.ToString() + "/" + _currentWeapon.AmmoLeft.ToString();
    }

    public static void UpdateTimeDisplay(string playerTime)
    {
        _timeDisplay.text = playerTime;
    }

    public static void UpdateWeaponDisplay()
    {

        _currentWeaponDisplay.text = _currentWeapon.Name;
        _ammoDisplay.text = _currentWeapon.Mag.ToString() + "/" + _currentWeapon.AmmoLeft.ToString();
    }

    public static void SetCurrentWeapon()
    {
        _currentWeapon = PlayerBackpack.currentWeapon;
    }
}
