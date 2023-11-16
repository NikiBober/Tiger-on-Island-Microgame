using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Controls player movement
/// </summary>

public class PlayerController : RigidbodyMovement
{
    //stop movement
    private void FixedUpdate()
    {
        if (Input.touchCount == 0)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
    
    //move player with speed
    private void OnMove (InputValue movementValue)
    {
        _rigidbody.AddForce(movementValue.Get<Vector2>() * _speed);
    }

    //detect game over condition
    private void OnTriggerExit2D(Collider2D collision)
    {
        EventManager.GameOver();
    }
}
