using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
/// <summary>
/// Manages UI 
/// </summary>

public class UIManager : MonoBehaviour
{
    [Header("UI elements")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _inGameMenu;
    [SerializeField] private GameObject _gameOverMenu;

    private void OnEnable()
    {
        EventManager.OnGameOver += GameOverHandler;
        EventManager.OnScoreUpdate += ScoreUpdateHandler;
    }
    
    private void OnDisable()
    {
        EventManager.OnGameOver -= GameOverHandler;
        EventManager.OnScoreUpdate -= ScoreUpdateHandler;
    }

    //change time scale and show resume button
    public void TogglePause()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 0.0f;
            _pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            _pauseMenu.SetActive(false);
        }
    }

    // Load MainScene
    public void StartGame()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("MainScene");
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
}
