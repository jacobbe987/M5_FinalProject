using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,
        Captured
    }


    public static GameManager Instance { get; private set; }


    [SerializeField] private int _maxAttempts;


    public GameState _gameState;
    private int _currentAttempts;
    public int CurrentAttempts => _currentAttempts;


    public static event Action<int> OnAttemptFailed;
    public static event Action OnGameOver;
    public static event Action OnGameCompleted;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }

    private void Start()
    {
        _currentAttempts = _maxAttempts;
    }

    private void GameOver()
    {
        OnGameOver?.Invoke();
        Time.timeScale = 0;
    }

    public void GameCompleted()
    {
        OnGameCompleted?.Invoke();
        Time.timeScale = 0;
    }
    private void Respawn()
    {
        _gameState = GameState.Playing;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void AttemptFailed()
    {
        _currentAttempts--;
        OnAttemptFailed?.Invoke(_currentAttempts);



        if ( _currentAttempts <= 0)
        {
            GameOver();
        }
        else
        {
            Respawn();
        }
    }

    public void PlayerCaptured()
    {
        _gameState = GameState.Captured;
        AttemptFailed();
        
    }

    public void GameRestarted()
    {
        _currentAttempts = _maxAttempts;
        _gameState = GameState.Playing;
        Time.timeScale = 1;
    }
}
