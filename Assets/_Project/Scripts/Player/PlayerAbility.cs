using UnityEngine;
using DG.Tweening;
using Zenject;
using TheLine.Enum;
using TheLine.UI;
using TheLine.Utils;


namespace TheLine.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerAbility : MonoBehaviour
    {
        [SerializeField] float smallTime;
        [SerializeField] Vector3 smallScale;
        [SerializeField] float destroyTime;
        [SerializeField] Gradient destroyGradient;
        [SerializeField] float colorChangeDuration;


        [Inject] SkillTimeView skillTimeView;


        Vector3 startScale;
        SpriteRenderer spriteRenderer;
        Color startColor;

        public bool IsDestroyer { get; private set; }


        void Awake()
        {
            startScale = transform.localScale;
            spriteRenderer = GetComponent<SpriteRenderer>();
            startColor = spriteRenderer.color;
        }

        void OnDisable()
        {
            DOTween.Kill(spriteRenderer);
        }


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
            skillTimeView.Run(smallTime);
            transform.localScale = smallScale;
            this.Wait(smallTime, CancelSmall);
        }

        private void CancelSmall()
        {
            transform.localScale = startScale;
        }

        private void MakeDestoyer()
        {
            IsDestroyer = true;
            skillTimeView.Run(destroyTime);
            spriteRenderer.DOGradientColor(destroyGradient, colorChangeDuration).SetLoops(-1);
            this.Wait(destroyTime, CancelDestoyer);
        }

        private void CancelDestoyer()
        {
            IsDestroyer = false;
            DOTween.Kill(spriteRenderer);
            spriteRenderer.color = startColor;
        }
    }
}
