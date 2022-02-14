using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    [SerializeField] private TankManager tank1, tank2;
    
    private float _timer = 10.00f;

    private bool _gameFinished;

    private void Update()
    {
        DecreaseGameTimer();
    }

    private void DecreaseGameTimer()
    {
        if (_gameFinished) return;
        
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

    private void StopTanks()
    {
        tank1.gameFinished = true;
        //tank2.gameFinished = true;
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