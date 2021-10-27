using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _templates;
    [SerializeField] private readonly float _startSecondBetweenSpawn;
    [SerializeField] private Score _score;
    [SerializeField] private Player _player;

    private float _secondBetweenSpawnDecrease = 1.1f;
    private float _secondBetweenSpawn ;
    private float _minSecondBetweenSpawn = 0.4f;
    private float _elapsedTime = 0;

    private int _lastIncreasePoints = 0;
    private int _pointDifference = 5;

    public float StartSecondBetweenSpawn => _startSecondBetweenSpawn;
    public float MinSecondBetweenSpawn => _minSecondBetweenSpawn;

    public event UnityAction<float> SpawnSpeedChanged;

    private void OnEnable()
    {
        _score.ScoreChanged += OnScoreChanged;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _score.ScoreChanged -= OnScoreChanged;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        _secondBetweenSpawn = _startSecondBetweenSpawn;
    }
    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondBetweenSpawn)
        {
            int numberEnemy = Random.Range(0, _templates.Count);
            GameObject spawned = Instantiate(_templates[numberEnemy], transform);
            
            _elapsedTime = 0;
        }
    }
    private void OnScoreChanged(int currentScore)
    {
        if ((_lastIncreasePoints + _pointDifference) <= currentScore)
        {
            IncreaseSpawnSpeed();
            _lastIncreasePoints = currentScore;
        }
    }

    private void IncreaseSpawnSpeed()
    {
        if (_secondBetweenSpawn > _minSecondBetweenSpawn)
        {
            _secondBetweenSpawn = _secondBetweenSpawn / _secondBetweenSpawnDecrease;
        }

        SpawnSpeedChanged?.Invoke(_secondBetweenSpawn);
    }

    private void OnGameOver()
    {
        _secondBetweenSpawn = _startSecondBetweenSpawn;
        SpawnSpeedChanged?.Invoke(_secondBetweenSpawn);
    }
}
