using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private SwipeZone _swipeZone;

    [SerializeField] private int _startHealth;

    private int _currentHealth;

    public event UnityAction GameOver;

    private void OnEnable()
    {
        _swipeZone.CubeSkipped += OnCubeSkipped;
    }

    private void OnDisable()
    {
        _swipeZone.CubeSkipped -= OnCubeSkipped;
    }

    private void Start()
    {
        _currentHealth = _startHealth;
    }

    private void OnCubeSkipped()
    {
        DecreaseHealth();
    }

    private void DecreaseHealth()
    {
        _currentHealth--;
        if (_currentHealth <= 0)
            FinishGame();
    }

    private void FinishGame()
    {
        GameOver?.Invoke();
        Time.timeScale = 0;
        _currentHealth = _startHealth;
    }
}
