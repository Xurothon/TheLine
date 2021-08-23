using UnityEngine;
using Zenject;
using TheLine.Maze;


namespace TheLine.ObjectPool
{
    public class MazePieceObjectPool : TheLine.ObjectPool.ObjectPool<Maze.MazePiece>
    {
        [SerializeField] Vector2Int mazeSize;


        [Inject] MazePieceCreator mazePieceCreator;
        [Inject] MazePositioner mazePositioner;


        public Vector2Int MazeSize => mazeSize;


        void Awake()
        {
            Initialize();
        }

        new void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < objectCount; i++)
            {
                mazePieceCreator.Create(mazeSize, objects[i]);
                objects[i].Initialize(endPoint.position, mazePositioner);
            }
        }
    }
}