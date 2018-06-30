using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    static short _playerMaxHP;
    static short _playerCurrentHP;
    [SerializeField]
    private GameOver _gameOverObject;
    PlayerSounds _sounds;

    public static short MaxHP
    {
        get { return _playerMaxHP; }
    }

    public static short CurrentHP
    {
        get { return _playerCurrentHP; }
    }

    void Start()
    {
        if (LevelMode.currentLevelMode != Mode.OneHitKill)
            _playerMaxHP = 100;
        else
            _playerMaxHP = 1;
        _playerCurrentHP = _playerMaxHP;
        _sounds = gameObject.GetComponentInChildren<PlayerSounds>();
    }

    public void DealDamageToPlayer(short damage)
    {
        _playerCurrentHP -= damage;
        _sounds.PlayGruntSound();
        HUD.UpdateHPDisplay();   
        if (IsDead())
        {
            Time.timeScale = 0;
            _gameOverObject.DisplayGameOverScreen();
        }
    }

    public void HealPlayer(short heal)
    {
        short diff = (short)(_playerMaxHP - _playerCurrentHP);
        if (diff <= heal)
            _playerCurrentHP += diff;
        else
            _playerCurrentHP += heal;
        HUD.UpdateHPDisplay();
    }

    private bool IsDead()
    {
        if (_playerCurrentHP <= 0)
            return true;
        else
            return false;
    }
}		