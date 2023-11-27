using UnityEngine;

/// <summary>
/// Save data between sessions
/// </summary>


public class SaveData : MonoBehaviour
{
    private static string _coinsScoreLabel = "CoinsScore";
    private static string _skinLabel = "Skin";
    private static string _currentSkinLabel = "CurrentSkin";
    private static int _skinOwnedValue = 1;

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

    public static bool IsSkinOwned(int skinIndex)
    {
        bool isOwned = PlayerPrefs.GetInt(_skinLabel + skinIndex.ToString()) == _skinOwnedValue;
        return isOwned;
    }

    public static void UnlockSkin(int skinIndex)
    {
        PlayerPrefs.SetInt(_skinLabel + skinIndex.ToString(), _skinOwnedValue);
    }

    public static int GetCurrentSkinIndex()
    {
        return PlayerPrefs.GetInt(_currentSkinLabel);
    }

    public static void SaveCurrentSkinIndex(int skinIndex)
    {
        PlayerPrefs.SetInt(_currentSkinLabel, skinIndex);
    }

    private void SaveCoinsScore()
    {
        _coinsScore += ScoreCounter.Score;
        PlayerPrefs.SetInt(_coinsScoreLabel, _coinsScore);
    }
}
