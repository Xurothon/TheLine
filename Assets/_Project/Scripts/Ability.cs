using UnityEngine;
using DG.Tweening;
using TheLine.Enum;

namespace TheLine
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ability : MonoBehaviour
    {
        [SerializeField] Gradient gardient;
        [SerializeField] float colorChangeDuration;


        SpriteRenderer spriteRenderer;


        public Skill Mode { get; private set; }
        public Vector3 EndPoint { get; private set; }


        void OnEnable()
        {
            Mode = (Skill)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(Skill)).Length);
            spriteRenderer.DOGradientColor(gardient, colorChangeDuration).SetLoops(-1);
        }

        void OnDisable()
        {
            DOTween.Kill(spriteRenderer);
            spriteRenderer.enabled = true;
        }

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }


        public void Initialize(Vector3 endPoint)
        {
            EndPoint = endPoint;
        }

        public void DisableSpriteRenderer()
        {
            spriteRenderer.enabled = false;
        }
    }
}