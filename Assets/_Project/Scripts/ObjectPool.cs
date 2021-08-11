using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPool : MonoBehaviour
{
    public Vector2Int MazeSize => _mazeSize;
    [SerializeField] private int _mazePieceCount;
    [SerializeField] private int _abilityCount;
    [SerializeField] private MazePiece _mazeTemplate;
    [SerializeField] private Ability _abilityTemplate;
    [SerializeField] private Vector2Int _mazeSize;
    [SerializeField] private Transform _endPoint;
    [Inject] private MazePieceCreator _mazePieceCreator;
    [Inject] private MazePositioner _mazePositioner;
    private List<MazePiece> _mazeObjects;
    private List<Ability> _abilityObjects;

    public MazePiece GetMazePiece()
    {
        for (int i = 0; i < _mazeObjects.Count; i++)
        {
            if (_mazeObjects[i].gameObject.activeInHierarchy == false)
            {
                _mazeObjects[i].gameObject.SetActive(true);
                return _mazeObjects[i];
            }
        }
        CreateMazePiece();
        _mazeObjects[_mazeObjects.Count - 1].gameObject.SetActive(true);
        return _mazeObjects[_mazeObjects.Count - 1];
    }

    public Ability GetAbility()
    {
        for (int i = 0; i < _abilityObjects.Count; i++)
        {
            if (_abilityObjects[i].gameObject.activeInHierarchy == false)
            {
                _abilityObjects[i].gameObject.SetActive(true);
                return _abilityObjects[i];
            }
        }
        CreateAbility();
        _abilityObjects[_abilityObjects.Count - 1].gameObject.SetActive(true);
        return _abilityObjects[_abilityObjects.Count - 1];
    }

    private void Initialize()
    {
        _mazeObjects = new List<MazePiece>();
        _abilityObjects = new List<Ability>();
        for (int i = 0; i < _mazePieceCount; i++)
        {
            CreateMazePiece();
        }

        for (int i = 0; i < _abilityCount; i++)
        {
            CreateAbility();
        }
    }

    private MazePiece CreateMazePiece()
    {
        MazePiece temp = Instantiate(_mazeTemplate);
        _mazeObjects.Add(temp);
        _mazePieceCreator.Create(_mazeSize, temp);
        temp.Initialize(_endPoint.position, _mazePositioner);
        temp.gameObject.SetActive(false);
        return temp;
    }

    private Ability CreateAbility()
    {
        Ability temp = Instantiate(_abilityTemplate);
        _abilityObjects.Add(temp);
        temp.Initialize(_endPoint.position);
        temp.gameObject.SetActive(false);
        return temp;
    }

    private void Awake()
    {
        Initialize();
    }
}
