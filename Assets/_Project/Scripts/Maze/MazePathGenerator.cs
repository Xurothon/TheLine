using UnityEngine;
using Zenject;

namespace TheLine.Maze
{
    public class MazePathGenerator : MonoBehaviour
    {
        [SerializeField] Vector2 sideOffectChance;
        [SerializeField] [Range(0f, 1f)] float abilitySpawnChance;


        [Inject] MazePositioner mazePositioner;
        [Inject] TheLine.ObjectPool.AbilityObjectPool objectPool;


        int openBlock;


        void Awake()
        {
            openBlock = Random.Range(0, mazePositioner.MazeSize.x);
        }


        public void CreatePath(MazePiece mazePiece)
        {
            ActiveAllBlocks(mazePiece);
            for (int i = 0; i < mazePositioner.MazeSize.y; i++)
            {
                DisableBlock(mazePiece, i);
            }
        }


        void DisableBlock(MazePiece mazePiece, int i)
        {
            mazePiece.Maze[i, openBlock].gameObject.SetActive(false);
            float randomChance = Random.Range(0f, 1f);
            if (randomChance <= abilitySpawnChance)
            {
                Ability temp = objectPool.GetObject();
                temp.transform.position = mazePiece.Maze[i, openBlock].transform.position;
                mazePiece.AddAbility(temp);
            }
            if (randomChance < sideOffectChance.x)
            {
                if (IsHasNextBlock(mazePiece, openBlock - 1))
                {
                    openBlock--;
                    DisableBlock(mazePiece, i);
                }
            }
            else if (randomChance > sideOffectChance.y)
            {
                if (IsHasNextBlock(mazePiece, openBlock + 1))
                {
                    openBlock++;
                    DisableBlock(mazePiece, i);
                }
            }
        }

        void ActiveAllBlocks(MazePiece mazePiece)
        {
            for (int i = 0; i < mazePositioner.MazeSize.y; i++)
            {
                for (int j = 0; j < mazePositioner.MazeSize.x; j++)
                {
                    mazePiece.Maze[i, j].gameObject.SetActive(true);
                }
            }
        }

        bool IsHasNextBlock(MazePiece mazePiece, int nextBlock)
        {
            return (nextBlock >= 0) && (nextBlock < mazePositioner.MazeSize.x);
        }
    }
}
