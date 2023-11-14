using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Controls player movement
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 0.01f;
    private Rigidbody2D _playerRigidbody;

    // get reference to player`s rigidbody
    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    //stop movement
    private void FixedUpdate()
    {
        if (Input.touchCount == 0)
        {
            _playerRigidbody.velocity = Vector2.zero;
        }
    }
    
    //move player with speed
    private void OnMove (InputValue movementValue)
    {
        _playerRigidbody.AddForce(movementValue.Get<Vector2>() * _movementSpeed);
    }
}
