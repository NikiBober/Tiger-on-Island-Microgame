using System.Collections;
using UnityEngine;

public class ScaleOverTime : MonoBehaviour
{
    [SerializeField] private float _decreaseRate = 0.1f;
    [SerializeField] private float _minLimit = 0.1f;

    private Vector3 _changeScale;
    private Vector3 _minScale;

    private void Start()
    {
        _changeScale = Vector3.one * _decreaseRate;
        _minScale = Vector3.one * _minLimit;
        StartCoroutine(ScaleRoutine());
    }

    private IEnumerator ScaleRoutine()
    {
        while (transform.localScale.x > _minScale.x)
        {
            transform.localScale -= _changeScale * Time.deltaTime;
            yield return null;
        }
    }
}
