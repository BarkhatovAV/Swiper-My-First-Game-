using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private SwipeZone _swipeZone;
    [SerializeField] private Player _player;

    private int _currentScore;

    public event UnityAction<int> ScoreChanged;
    public event UnityAction DifficultyChanged;

    private void OnEnable()
    {
        _swipeZone.SwipeAccepted += OnSwipeAccepted;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _swipeZone.SwipeAccepted -= OnSwipeAccepted;
        _player.GameOver -= OnGameOver;
    }


    private void OnSwipeAccepted()
    {
        IncreaseScore();
    }

    private void IncreaseScore()
    {
        _currentScore++;
        ScoreChanged?.Invoke(_currentScore);
    }    

    private void OnGameOver()
    {
        ScoreChanged?.Invoke(_currentScore);
        _currentScore = 0;
    }
}
