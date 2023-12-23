using UnityEngine;

/// <summary>
/// Save data between sessions
/// </summary>

public class SaveData : MonoBehaviour
{
    private static string _coinsScoreLabel = "CoinsScore";
    private static string _skinLabel = "Skin";
    private static string _currentSkinLabel = "CurrentSkin";
    private static string _abilityLabel = "Ability";

    private static int _startAbilityCount = 1;
    private static int _skinOwnedValue = 1;

    private static int _coinsScore = 0;
    public static int CoinsScore { get => _coinsScore; }

    private void OnEnable()
    {
        EventManager.OnGameOver += GameOverHandler;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= GameOverHandler;
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

    public static int GetCurrentSkinIndex()
    {
        return PlayerPrefs.GetInt(_currentSkinLabel);
    }

    public static void SaveCurrentSkinIndex(int skinIndex)
    {
        PlayerPrefs.SetInt(_currentSkinLabel, skinIndex);
    }

    public static void UnlockSkin(int skinIndex)
    {
        PlayerPrefs.SetInt(_skinLabel + skinIndex.ToString(), _skinOwnedValue);
    }

    public static void ChangeAbilityCount(int abilityIndex, int amount)
    {
        int count = GetAbilityCount(abilityIndex);
        count += amount;
        PlayerPrefs.SetInt(_abilityLabel + abilityIndex.ToString(), count);
    }

    public static int GetAbilityCount(int abilityIndex)
    {
        int count = PlayerPrefs.GetInt(_abilityLabel + abilityIndex.ToString(), _startAbilityCount);
        return count;
    }

    public static void UpdateCoinsScore (int amount)
    {
        _coinsScore += amount;
        PlayerPrefs.SetInt(_coinsScoreLabel, _coinsScore);
    }

    private void GameOverHandler()
    {
        UpdateCoinsScore(ScoreCounter.Score);
    }
}
