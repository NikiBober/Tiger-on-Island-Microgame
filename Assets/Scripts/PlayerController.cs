using UnityEngine;
/// <summary>
/// Controls player movement
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed = 0.01f;
    private Touch _theTouch;
    private Vector2 _touchStartPosition, _touchEndPosition;
    private Vector2 _velocity;
    private Rigidbody2D _playerRigidbody;

    // get reference to player`s rigidbody
    private void Start()
    {
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    //take input and do movements
    private void FixedUpdate()
    {
        ReadInput();
        MovePlayer(_velocity);
    }

    private void ReadInput()
    {
        if (Input.touchCount > 0)
        {
            _theTouch = Input.GetTouch(0);

            if (_theTouch.phase == TouchPhase.Began)
            {
                _touchStartPosition = _theTouch.position;
            }

            else if (_theTouch.phase == TouchPhase.Moved)
            {
                _touchEndPosition = _theTouch.position;

                float x = _touchEndPosition.x - _touchStartPosition.x;
                float y = _touchEndPosition.y - _touchStartPosition.y;
                _velocity = new Vector2(x, y);
            }
            else if (_theTouch.phase == TouchPhase.Ended)
            {
                _velocity = Vector2.zero;
            }
        }
    }

    // move player`s rigidbody
    private void MovePlayer (Vector2 velocity)
    {
        _playerRigidbody.velocity = velocity * _movementSpeed;
    }
}
