using UnityEngine;

public class DisablePoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Block block))
        {
            if (block.transform.parent.TryGetComponent(out MazePiece maze))
            {
                if (maze.gameObject.activeInHierarchy)
                {
                    maze.Disable();
                }
            }
        }
    }
}