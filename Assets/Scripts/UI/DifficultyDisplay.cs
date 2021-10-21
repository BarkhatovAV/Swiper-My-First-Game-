using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyDisplay : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Slider _slider;
    
    private float _minDificulty;
    private float _maxDificulty;
    private float _currentDificulty;

    private void OnEnable()
    {
        _spawner.SpawnSpeedChanged += OnSpawnSpeedChanged;
    }

    private void OnDisable()
    {
        _spawner.SpawnSpeedChanged -= OnSpawnSpeedChanged;
    }

    private void Start()
    {
        _minDificulty = _spawner.StartSecondBetweenSpawn;
        _slider.maxValue = _minDificulty;
        _maxDificulty = _spawner.MinSecondBetweenSpawn;
        _slider.minValue = _maxDificulty;
        _slider.value = _minDificulty;
    }

    private void OnSpawnSpeedChanged(float currentDificulty)
    {
        _slider.value = currentDificulty;
    }
}
