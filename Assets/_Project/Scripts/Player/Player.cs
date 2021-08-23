using UnityEngine;
using UnityEngine.Events;
using TheLine.Maze;

namespace TheLine.Player
{
    [RequireComponent(typeof(PlayerMovable), typeof(PlayerAbility))]
    public class Player : MonoBehaviour
    {
        public event UnityAction OnDied;


        PlayerMovable playerMovable;
        PlayerAbility playerAbility;


        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Block block))
            {
                if (playerAbility.IsDestroyer)
                {
                    block.Destroy();
                }
                else
                {
                    OnDied?.Invoke();
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Ability ability))
            {
                playerAbility.ActiveAbility(ability);
                ability.DisableSpriteRenderer();
            }
        }

        void Awake()
        {
            playerMovable = GetComponent<PlayerMovable>();
            playerAbility = GetComponent<PlayerAbility>();
        }


        public void SetStartPosition(Vector2 point)
        {
            point.y = transform.position.y;
            transform.position = point;
        }

        public void Move(Vector2 direction)
        {
            playerMovable.Move(direction);
        }
    }
}
