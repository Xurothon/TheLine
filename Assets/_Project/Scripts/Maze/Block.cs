using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private bool _isCanDestroy;

    public void Destroy()
    {
        if (_isCanDestroy)
        {
            gameObject.SetActive(false);
        }
    }
}