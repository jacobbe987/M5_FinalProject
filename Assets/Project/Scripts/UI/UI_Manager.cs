using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _attemptsText;
    [SerializeField] private GameObject _gameoverCanvas;
    [SerializeField] private GameObject _gamecompletedCanvas;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            UpdateAttempts(GameManager.Instance.CurrentAttempts);
        }
    }

    private void OnEnable()
    {
        GameManager.OnAttemptFailed += UpdateAttempts;
        GameManager.OnGameOver += GameOverCanvas;
        GameManager.OnGameCompleted += GameCompletedCanvas;
    }

    private void OnDisable()
    {
        GameManager.OnAttemptFailed -= UpdateAttempts;
        GameManager.OnGameOver -= GameOverCanvas;
        GameManager.OnGameCompleted -= GameCompletedCanvas;
    }

    private void UpdateAttempts(int attempts)
    {
        _attemptsText.text = "Attempts: " + attempts;
    }

    private void GameOverCanvas()
    {
        _gameoverCanvas.SetActive(true);
    }

    private void GameCompletedCanvas()
    {
        _gamecompletedCanvas.SetActive(true);
    }
}
