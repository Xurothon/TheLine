using UnityEngine;

public class MazePieceCreator : MonoBehaviour
{
    [SerializeField] private Block _template;

    public void Create(Vector2Int size, MazePiece parent)
    {
        Vector2 startPosition = GetBlockStartPosition(size);
        Block[,] maze = new Block[size.y, size.x];
        for (int i = 0; i < size.y; i++)
        {
            for (int j = 0; j < size.x; j++)
            {
                maze[i, j] = Instantiate(_template, parent.transform);
                maze[i, j].transform.localPosition = startPosition + new Vector2(j, i);
            }
        }
        parent.BlockInitialize(maze);
    }

    private Vector2Int GetBlockStartPosition(Vector2Int size)
    {
        return -1 * new Vector2Int(size.x, size.y) / 2;
    }
}
