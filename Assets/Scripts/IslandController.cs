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

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            _rigidbody.velocity = Random.insideUnitCircle.normalized * _movementSpeed;
            yield return new WaitForSeconds(_delay);
        }
    }
}
