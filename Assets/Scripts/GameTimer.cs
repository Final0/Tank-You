using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    
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
        timerText.text = _timer.ToString("#.00");

        GameFinished();
    }

    private void GameFinished()
    {
        if (!(_timer <= 0f)) return;
        
        _gameFinished = true;
        _timer = 0f;
        timerText.text = "0";
    }
}