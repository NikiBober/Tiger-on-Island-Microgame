using System.Collections;
using UnityEngine;
/// <summary>
/// Increase score by points amount every delay interval
/// </summary>

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _delay = 1.0f;
    [SerializeField] private int _points = 1;
    
    private int _score = 0;
    private int _coinsScore = 0;

    private void OnEnable()
    {
        EventManager.OnGameOver += SaveCoinsScore;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= SaveCoinsScore;
    }

    private void Start()
    {
        _coinsScore = PlayerPrefs.GetInt("CoinsScore");
        StartCoroutine(CountScoreRoutine());
    }

    private IEnumerator CountScoreRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            _score += _points;
            EventManager.ScoreUpdate(_score);
        }
    }

    private void SaveCoinsScore()
    {
        _coinsScore += _score;
        PlayerPrefs.SetInt("CoinsScore", _coinsScore);
    }
}
