public class EventManager
{
    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;

    // Start is called before the first frame update
    public static void GameOver()
    {
        OnGameOver();
    }
}
