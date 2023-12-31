using System.Collections;
using UnityEngine;

/// <summary>
/// Increase score by points amount every delay interval
/// </summary>

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _delay = 1.0f;
    [SerializeField] private int _points = 1;
    
    private static int _score;
    public static int Score { get => _score; }


    private void Start()
    {
        _score = 0;
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
}
