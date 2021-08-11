using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Ability))]
public class AbilityMovable : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Ability _ability;

    public void Move()
    {
        float duration = Vector2.Distance(_ability.EndPoint, transform.position) / _speed;
        transform.DOMove(_ability.EndPoint, duration);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }

    private void Awake()
    {
        _ability = GetComponent<Ability>();
    }
}
