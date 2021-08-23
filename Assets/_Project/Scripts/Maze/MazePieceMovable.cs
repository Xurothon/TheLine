using UnityEngine;
using DG.Tweening;

namespace TheLine.Maze
{

    [RequireComponent(typeof(MazePiece))]
    public class MazePieceMovable : MonoBehaviour
    {
        [SerializeField] float speed;


        private MazePiece _mazePiece;

        void Awake()
        {
            _mazePiece = GetComponent<MazePiece>();
        }

        void OnDisable()
        {
            DOTween.Kill(transform);
        }


        public void Move()
        {
            float duration = Vector2.Distance(_mazePiece.EndPoint, transform.position) / speed;
            transform.DOMove(_mazePiece.EndPoint, duration);
        }

    }
}
