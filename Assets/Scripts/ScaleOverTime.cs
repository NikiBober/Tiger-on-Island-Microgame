using System.Collections;
using UnityEngine;

/// <summary>
/// Decrease scale every frame till min limit is reached
/// </summary>

public class ScaleOverTime : MonoBehaviour
{
    [SerializeField] private float _decreaseAmount = 0.1f;
    [SerializeField] private float _minLimit = 0.1f;

    private Vector3 _changeScale;
    private Vector3 _minScale;

    private void Start()
    {
        _changeScale = Vector3.one * _decreaseAmount;
        _minScale = Vector3.one * _minLimit;
        StartCoroutine(DecreaseScaleRoutine());
    }

    private IEnumerator DecreaseScaleRoutine()
    {
        while (transform.localScale.x > _minScale.x)
        {
            transform.localScale -= _changeScale * Time.deltaTime;
            yield return null;
        }
    }
}
