using UnityEngine;
using Zenject;

namespace TheLine.Maze
{
    public class MazePositioner : MonoBehaviour
    {
        [SerializeField] Transform start;
        [SerializeField] int generateCount;


        [Inject] MazePathGenerator mazePathGenerator;
        [Inject] TheLine.ObjectPool.MazePieceObjectPool objectPool;


        MazePiece lastActiveMazePiece;

        public Vector2Int MazeSize => objectPool.MazeSize;


        void Start()
        {
            SetPosition();
        }


        public void ActiveMazePiece()
        {
            MazePiece piece = objectPool.GetObject();
            piece.transform.position = lastActiveMazePiece.transform.position + new Vector3(0, MazeSize.y, 0);
            mazePathGenerator.CreatePath(piece);
            piece.Move();
            lastActiveMazePiece = piece;
        }


        void SetPosition()
        {
            for (int i = 0; i < generateCount; i++)
            {
                MazePiece piece = objectPool.GetObject();
                piece.transform.position = start.position + new Vector3(0, MazeSize.y * i, 0);
                mazePathGenerator.CreatePath(piece);
                piece.Move();
                lastActiveMazePiece = piece;
            }
        }
    }
}