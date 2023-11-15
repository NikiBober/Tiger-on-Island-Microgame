using System.Collections;
using UnityEngine;
/// <summary>
/// Increase score by points amount every delay interval
/// </summary>

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float _delay = 1.0f;
    [SerializeField] private int _points = 1;
    [SerializeField] private int _score = 0;

    private void Start()
    {
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
