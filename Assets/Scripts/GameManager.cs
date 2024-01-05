using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Load scene and pause functions here
/// </summary>

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private GameObject _tutorialScreen;


    [SerializeField] private float _normalTimeScale = 1.0f;
    [SerializeField] private float _pauseTimeScale = 0.0f;

    private void Start()
    {
        if (SaveData.IsFirstLaunch())
        {
            _tutorialScreen.SetActive(true);
        }
    }
    public void LoadScene(string sceneToLoad)
    {
        Time.timeScale = _normalTimeScale;
        _loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneRoutine(sceneToLoad));
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

    private IEnumerator LoadSceneRoutine(string sceneToLoad)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f) * 100;

            _progressBar.value = progress;
            _progressText.text = $"Loading... {Mathf.Round(progress)}%";

            yield return null;
        }
    }

    public void PlaySound(int id)
    {
        AudioManager.Instance.PlaySound(id);
    }
}
