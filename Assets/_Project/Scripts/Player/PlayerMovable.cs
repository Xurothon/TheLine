using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovable : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public void SetStartPosition(Vector2 point)
    {
        point.y = transform.position.y;
        transform.position = point;
    }

    public void Move(Vector2 direction)
    {
        direction.y = transform.position.y;
        _rigidbody.MovePosition(direction);
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}
