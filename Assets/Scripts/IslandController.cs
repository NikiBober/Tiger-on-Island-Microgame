using System.Collections;
using UnityEngine;
/// <summary>
/// Controls island movement and abilities
/// </summary>

public class IslandController : RigidbodyMovement
{
    [SerializeField] private float _delay = 1.0f;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(ChangeDirectionRoutine());
    }

    private IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            _rigidbody.velocity = Random.insideUnitCircle.normalized * _speed;
            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator ChangeSpeedRoutine()
    {
        yield return new WaitForSeconds(_delay);
    }
}
