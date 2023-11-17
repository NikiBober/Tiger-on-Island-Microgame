using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

/// <summary>
/// Parent class for movable objects
/// </summary>

public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] protected float _speed = 1.0f;
    public float Speed { get => _speed; set => _speed = value; }

    protected Rigidbody2D _rigidbody;

    // get reference to rigidbody
    protected virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
