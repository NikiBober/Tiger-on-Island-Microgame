using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        gameObject.SetActive(SaveData.IsFirstLaunch());
    }
}
