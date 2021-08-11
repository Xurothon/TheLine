using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MazePiece))]
public class MazePieceMovable : MonoBehaviour
{
    [SerializeField] private float _speed;
    private MazePiece _mazePiece;

    public void Move()
    {
        float duration = Vector2.Distance(_mazePiece.EndPoint, transform.position) / _speed;
        transform.DOMove(_mazePiece.EndPoint, duration);
    }

    private void OnDisable()
    {
        DOTween.Kill(transform);
    }

    private void Awake()
    {
        _mazePiece = GetComponent<MazePiece>();
    }
}
