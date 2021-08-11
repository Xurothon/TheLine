using UnityEngine;
using Zenject;

public class MazePathGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _sideOffectChance;
    [Range(0f, 1f)] [SerializeField] private float _abilitySpawnChance;
    [Inject] private MazePositioner _mazePositioner;
    [Inject] private ObjectPool _objectPool;
    private int _openBlock;

    public void CreatePath(MazePiece mazePiece)
    {
        ActiveAllBlocks(mazePiece);
        for (int i = 0; i < _mazePositioner.MazeSize.y; i++)
        {
            DisableBlock(mazePiece, i);
        }
    }

    private void DisableBlock(MazePiece mazePiece, int i)
    {
        mazePiece.Maze[i, _openBlock].gameObject.SetActive(false);
        float randomChance = Random.Range(0f, 1f);
        if (randomChance <= _abilitySpawnChance)
        {
            Ability temp = _objectPool.GetAbility();
            temp.transform.position = mazePiece.Maze[i, _openBlock].transform.position;
            mazePiece.AddAbility(temp);
        }
        if (randomChance < _sideOffectChance.x)
        {
            if (IsHasNextBlock(mazePiece, _openBlock - 1))
            {
                _openBlock--;
                DisableBlock(mazePiece, i);
            }
        }
        else if (randomChance > _sideOffectChance.y)
        {
            if (IsHasNextBlock(mazePiece, _openBlock + 1))
            {
                _openBlock++;
                DisableBlock(mazePiece, i);
            }
        }
    }

    private void ActiveAllBlocks(MazePiece mazePiece)
    {
        for (int i = 0; i < _mazePositioner.MazeSize.y; i++)
        {
            for (int j = 0; j < _mazePositioner.MazeSize.x; j++)
            {
                mazePiece.Maze[i, j].gameObject.SetActive(true);
            }
        }
    }

    private bool IsHasNextBlock(MazePiece mazePiece, int nextBlock)
    {
        return (nextBlock >= 0) && (nextBlock < _mazePositioner.MazeSize.x);
    }

    private void Awake()
    {
        _openBlock = Random.Range(0, _mazePositioner.MazeSize.x);
    }
}
