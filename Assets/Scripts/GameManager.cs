using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject crown1Image, crown2Image;

    private static TankManager[] _tanks;
    
    private float _timer = 10.00f;

    private bool _gameFinished;

    private void Awake() => InitializeCrownsImages();

    private void Update()
    {
        if (_gameFinished || Time.timeScale == 0f) return;
        
        DecreaseGameTimer();
        DisplayCrownOnWinner();
    }

    public static void GetTanks() => _tanks = FindObjectsOfType<TankManager>();

    private void DecreaseGameTimer()
    {
        _timer -= Time.deltaTime;
        timerText.text = _timer.ToString("##.00");
        
        if(_timer <= 3f) timerText.color = Color.red;

        GameFinished();
    }

    private void GameFinished()
    {
        if (_timer > 0f) return;
        
        _gameFinished = true;
        _timer = 0f;
        timerText.text = "0";

        StopTanks();
        DeleteBullets();
    }

    private static void StopTanks()
    {
        foreach (var tank in _tanks)
        {
            tank.gameFinished = true;
        }
    }

    private static void DeleteBullets()
    {
        var bullets = FindObjectsOfType<Projectile>();

        foreach (var bullet in bullets)
        {
            Destroy(bullet.gameObject);
        }
    }

    private void InitializeCrownsImages()
    {
        crown1Image.SetActive(false);
        crown2Image.SetActive(false);
    }

    private void DisplayCrownOnWinner()
    {
        if (_tanks[1].damageCount < _tanks[0].damageCount)
        {
            crown1Image.SetActive(true);
            crown2Image.SetActive(false);
        }
        else if (_tanks[1].damageCount > _tanks[0].damageCount)
        {
            crown1Image.SetActive(false);
            crown2Image.SetActive(true);
        }
        else
        {
            if (_tanks[1].lastHit)
            {
                crown1Image.SetActive(false);
                crown2Image.SetActive(true);
            }
            else if (_tanks[0].lastHit)
            {
                crown1Image.SetActive(true);
                crown2Image.SetActive(false);
            }
        }
    }
}