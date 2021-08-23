using UnityEngine;

namespace TheLine.Maze
{
    public class Block : MonoBehaviour
    {
        [SerializeField] bool isCanDestroy;


        public void Destroy()
        {
            if (isCanDestroy)
            {
                gameObject.SetActive(false);
            }
        }
    }
}