using UnityEngine;
using TMPro;
using System.Collections;

/// <summary>
/// Manages UI 
/// </summary>

public class UIManager : Singleton<UIManager>
{
    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI[] _coinsScoreText;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _inGameMenu;
    [SerializeField] private GameObject _gameOverMenu;

    [SerializeField] private GameObject _notEnoughCoinsText;
    [SerializeField] private float _popUpDelay = 1.0f;

    [SerializeField] protected int _gameOverSoundId = 5;

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
        UpdateCoinsScoreText();
    }

    public void NotEnoughCoins()
    {
        StartCoroutine(NotEnoughCoinsRoutine());
    }

    public void UpdateCoinsScoreText()
    {
        string coinsText = SaveData.CoinsScore.ToString();
        foreach (TextMeshProUGUI textElement in _coinsScoreText)
        {
            textElement.text = coinsText;
        }
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
        AudioManager.Instance.PlaySound(_gameOverSoundId);
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

    private IEnumerator NotEnoughCoinsRoutine()
    {
        _notEnoughCoinsText.SetActive(true);
        yield return new WaitForSeconds(_popUpDelay);
        _notEnoughCoinsText.SetActive(false);
    }
}
