/// <summary>
/// Crosspoint for events
/// </summary>

public class EventManager
{
    public delegate void GameAction();
    public static event GameAction OnGameOver;
    public static event GameAction OnTogglePause;
    public static event GameAction OnUpdateAbility;

    public delegate void ScoreUpdateAction(int score);
    public static event ScoreUpdateAction OnScoreUpdate;
    public static event ScoreUpdateAction OnCoinsScoreUpdate;

    public static void GameOver()
    {
        OnGameOver();
    }

    public static void TogglePause()
    {
        OnTogglePause();
    }

    public static void UpdateAbility()
    {
        OnUpdateAbility();
    }

    public static void ScoreUpdate(int score)
    {
        OnScoreUpdate(score);
    }

    public static void CoinsScoreUpdate(int score)
    {
        OnCoinsScoreUpdate(score);
    }
}
