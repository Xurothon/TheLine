using UnityEngine;
using System;
using DG.Tweening;

[RequireComponent(typeof(SpriteRenderer))]
public class Ability : MonoBehaviour
{
    public Skill Mode { get; private set; }
    public Vector3 EndPoint { get; private set; }
    [SerializeField] private Gradient _gardient;
    [SerializeField] private float _colorChangeDuration;
    private SpriteRenderer _spriteRenderer;

    public void Initialize(Vector3 endPoint)
    {
        EndPoint = endPoint;
    }

    public void DisableSpriteRenderer()
    {
        _spriteRenderer.enabled = false;
    }

    private void OnEnable()
    {
        Mode = (Skill)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Skill)).Length);
        _spriteRenderer.DOGradientColor(_gardient, _colorChangeDuration).SetLoops(-1);
    }

    private void OnDisable()
    {
        DOTween.Kill(_spriteRenderer);
        _spriteRenderer.enabled = true;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
