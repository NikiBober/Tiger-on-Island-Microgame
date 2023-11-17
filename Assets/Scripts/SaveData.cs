using UnityEngine;

/// <summary>
/// Save coins amount between sessions
/// </summary>


public class SaveData : MonoBehaviour
{
    [SerializeField] private string _coinsScoreLabel = "CoinsScore";

    private static int _coinsScore = 0;
    public static int CoinsScore { get => _coinsScore; }

    private void OnEnable()
    {
        EventManager.OnGameOver += SaveCoinsScore;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= SaveCoinsScore;
    }

    private void Awake()
    {
        _coinsScore = PlayerPrefs.GetInt(_coinsScoreLabel);
    }

    private void SaveCoinsScore()
    {
        _coinsScore += ScoreCounter.Score;
        PlayerPrefs.SetInt(_coinsScoreLabel, _coinsScore);
    }
}
