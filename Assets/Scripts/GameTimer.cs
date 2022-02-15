using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    private static TankManager[] _tanks;
    
    private float _timer = 10.00f;

    private bool _gameFinished;
    
    private void Update() => DecreaseGameTimer();
    
    public static void GetTanks() => _tanks = FindObjectsOfType<TankManager>();

    private void DecreaseGameTimer()
    {
        if (_gameFinished || Time.timeScale == 0f) return;
        
        _timer -= Time.deltaTime;
        timerText.text = _timer.ToString("##.00");

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
}