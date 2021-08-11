using UnityEngine;
using Zenject;

public class MazePositioner : MonoBehaviour
{
    public Vector2Int MazeSize => _objectPool.MazeSize;
    [SerializeField] private Transform _start;
    [SerializeField] private int _generateCount;
    [Inject] private MazePathGenerator _mazePathGenerator;
    [Inject] private ObjectPool _objectPool;
    private MazePiece _lastActiveMazePiece;

    public void ActiveMazePiece()
    {
        MazePiece piece = _objectPool.GetMazePiece();
        piece.transform.position = _lastActiveMazePiece.transform.position + new Vector3(0, MazeSize.y, 0);
        _mazePathGenerator.CreatePath(piece);
        piece.Move();
        _lastActiveMazePiece = piece;
    }

    private void SetPosition()
    {
        for (int i = 0; i < _generateCount; i++)
        {
            MazePiece piece = _objectPool.GetMazePiece();
            piece.transform.position = _start.position + new Vector3(0, MazeSize.y * i, 0);
            _mazePathGenerator.CreatePath(piece);
            piece.Move();
            _lastActiveMazePiece = piece;
        }
    }

    private void Start()
    {
        SetPosition();
    }
}