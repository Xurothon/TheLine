using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;


[RequireComponent(typeof(PlayerMovable), typeof(PlayerAbility))]
public class Player : MonoBehaviour
{
    public event UnityAction Die;
    private PlayerMovable _playerMovable;
    private PlayerAbility _playerAbility;

    public void SetStartPosition(Vector2 point)
    {
        point.y = transform.position.y;
        transform.position = point;
    }

    public void Move(Vector2 direction)
    {
        _playerMovable.Move(direction);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Block block))
        {
            if (_playerAbility.IsDestroyer)
            {
                block.Destroy();
            }
            else
            {
                Die?.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Ability ability))
        {
            _playerAbility.ActiveAbility(ability);
            ability.DisableSpriteRenderer();
        }
    }

    private void Awake()
    {
        _playerMovable = GetComponent<PlayerMovable>();
        _playerAbility = GetComponent<PlayerAbility>();
    }
}
