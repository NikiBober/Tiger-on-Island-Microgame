/// <summary>
/// Crosspoint for events
/// </summary>

public class EventManager
{
    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;

    public delegate void ScoreUpdateAction(int score);
    public static event ScoreUpdateAction OnScoreUpdate;

    public static void GameOver()
    {
        OnGameOver();
    }

    public static void ScoreUpdate(int score)
    {
        OnScoreUpdate(score);
    }
}
