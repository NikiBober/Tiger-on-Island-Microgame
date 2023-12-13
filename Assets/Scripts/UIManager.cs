using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

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

    [SerializeField] private GameObject _notEnoughCoinsText;
    [SerializeField] private float _popUpDelay = 1.0f;

    [SerializeField] private TextMeshProUGUI[] _abilityCountText;

    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;

    public static UIManager Instance;

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

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateCoinsScoreText();
        for (int i = 0; i < _abilityCountText.Length; i++)
        {
            UpdateAbilityCount(i);
        }

        _musicVolumeSlider.value = AudioManager.Instance.GetMusicVolume();
        _soundVolumeSlider.value = AudioManager.Instance.GetSoundVolume();
    }

    public void NotEnoughCoins()
    {
        StartCoroutine(NotEnoughCoinsRoutine());
    }

    public void UpdateCoinsScoreText()
    {
        _coinsScoreText.text = SaveData.CoinsScore.ToString();
    }

    public void UpdateAbilityCount(int id)
    {
        _abilityCountText[id].text = SaveData.GetAbilityCount(id).ToString();
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

    private IEnumerator NotEnoughCoinsRoutine()
    {
        _notEnoughCoinsText.SetActive(true);
        yield return new WaitForSeconds(_popUpDelay);
        _notEnoughCoinsText.SetActive(false);
    }
}
