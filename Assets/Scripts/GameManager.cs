using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scene and pause functions here
/// </summary>

public class GameManager : MonoBehaviour
{
    [SerializeField] private string _gameSceneName = "MainScene";
    [SerializeField] private float _normalTimeScale = 1.0f;
    [SerializeField] private float _pauseTimeScale = 0.0f;

    // Load MainScene

    public void StartGame()
    {
        Time.timeScale = _normalTimeScale;
        SceneManager.LoadScene(_gameSceneName);
    }

    public void TogglePause()
    {
        if (Time.timeScale == _normalTimeScale)
        {
            Time.timeScale = _pauseTimeScale;
        }
        else
        {
            Time.timeScale = _normalTimeScale;
        }

        EventManager.TogglePause();
    }
}
