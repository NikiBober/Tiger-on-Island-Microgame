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

    //update in game score text
    public void UpdateScore(int score)
    {
        _scoreText.text = "Score: " + score;
    }

    //displays game over menu
    public void GameOver(int finalScore)
    {
        _scoreText.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(true);
        _gameOverText.text = "Your score is " + finalScore;
    }

    //change time scale
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
    
    // Load MainScene from start screen
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

}
