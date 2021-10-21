using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
        _gameOverScreen.Close();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();

        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();

        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _startScreen.Close();
        _gameOverScreen.Close();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        
        _gameOverScreen.Open();
        var foundCubes = FindObjectsOfType<Cube>();
        Debug.Log(foundCubes.Length);
        for (int i = 0; i < foundCubes.Length; i++)
        {
            Destroy(foundCubes[i].gameObject);
            Debug.Log(foundCubes[i]);
        }
    }
}
