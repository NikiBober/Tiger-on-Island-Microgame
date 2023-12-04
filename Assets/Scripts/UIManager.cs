using UnityEngine;
using TMPro;

/// <summary>
/// Manages UI 
/// </summary>

public class UIManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI _coinsScoreText;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _inGameMenu;
    [SerializeField] private GameObject _gameOverMenu;

    private void OnEnable()
    {
        EventManager.OnGameOver += GameOverHandler;
        EventManager.OnScoreUpdate += ScoreUpdateHandler;
        EventManager.OnTogglePause += TogglePauseHandler;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= GameOverHandler;
        EventManager.OnScoreUpdate -= ScoreUpdateHandler;
        EventManager.OnTogglePause -= TogglePauseHandler;
    }

    private void Start()
    {
        _coinsScoreText.text = SaveData.CoinsScore.ToString();
    }

    // display or hide pause menu
    private void TogglePauseHandler()
    {
        ToggleScreen(_pauseMenu);
    }

    //displays game over menu and change time scale
    private void GameOverHandler()
    {
        _inGameMenu.SetActive(false);
        _gameOverMenu.SetActive(true);
        _gameOverText.text = _scoreText.text;
        Time.timeScale = 0.0f;
    }

    //update in game score text
    private void ScoreUpdateHandler(int score)
    {
        _scoreText.text = score.ToString();
    }

    private void ToggleScreen(GameObject screen)
    {
        if (screen.activeSelf)
        {
            screen.SetActive(false);
        }
        else
        {
            screen.SetActive(true);
        }
    }

}
