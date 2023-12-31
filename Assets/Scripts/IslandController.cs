using System.Collections;
using UnityEngine;

/// <summary>
/// Controls island movement
/// </summary>

public class IslandController : RigidbodyMovement
{
    [SerializeField] private float _directionChangeInterval = 1.0f;
    [SerializeField] private float _acceleration = 1.0f;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(ChangeDirectionRoutine());
    }

    // increase speed every frame
    private void Update()
    {
        _speed += _acceleration * Time.deltaTime;
    }

    // change direction randomly every interval
    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            _rigidbody.velocity = Random.insideUnitCircle.normalized * _speed;
            yield return new WaitForSeconds(_directionChangeInterval);
        }
    }
}
