using UnityEngine;

namespace TheLine.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovable : MonoBehaviour
    {
        Rigidbody2D rigidbody;


        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }


        public void SetStartPosition(Vector2 point)
        {
            point.y = transform.position.y;
            transform.position = point;
        }

        public void Move(Vector2 direction)
        {
            direction.y = transform.position.y;
            rigidbody.MovePosition(direction);
        }
    }
}
