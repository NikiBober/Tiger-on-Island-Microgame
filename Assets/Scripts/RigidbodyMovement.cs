using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class RigidbodyMovement : MonoBehaviour
{
    [SerializeField] protected float _movementSpeed = 1.0f;
    protected Rigidbody2D _rigidbody;

    // get reference to rigidbody
    protected virtual void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
}
