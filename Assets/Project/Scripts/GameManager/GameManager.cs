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
        SceneManager.LoadScene(0);
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



        if ( _currentAttempts < 0)
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
}
