using UnityEngine;
using DG.Tweening;
using Zenject;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAbility : MonoBehaviour
{
    public bool IsDestroyer { get; private set; }
    [SerializeField] private float _smallTime;
    [SerializeField] private Vector3 _smallScale;
    [SerializeField] private float _destroyTime;
    [SerializeField] private Gradient _destroyGradient;
    [SerializeField] private float _colorChangeDuration;
    [Inject] private SkillTimeView _skillTimeView;
    private Vector3 _startScale;
    private SpriteRenderer _spriteRenderer;
    private Color _startColor;



    public void ActiveAbility(Ability ability)
    {
        if (ability.Mode == Skill.DESTROY)
        {
            MakeDestoyer();
        }
        else if (ability.Mode == Skill.SMALL)
        {
            MakeSmall();
        }
    }

    private void MakeSmall()
    {
        _skillTimeView.Run(_smallTime);
        transform.localScale = _smallScale;
        this.Wait(_smallTime, CancelSmall);
    }

    private void CancelSmall()
    {
        transform.localScale = _startScale;
    }

    private void MakeDestoyer()
    {
        IsDestroyer = true;
        _skillTimeView.Run(_destroyTime);
        _spriteRenderer.DOGradientColor(_destroyGradient, _colorChangeDuration).SetLoops(-1);
        this.Wait(_destroyTime, CancelDestoyer);
    }

    private void CancelDestoyer()
    {
        IsDestroyer = false;
        DOTween.Kill(_spriteRenderer);
        _spriteRenderer.color = _startColor;
    }

    private void Awake()
    {
        _startScale = transform.localScale;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startColor = _spriteRenderer.color;
    }

    private void OnDisable()
    {
        DOTween.Kill(_spriteRenderer);
    }
}
