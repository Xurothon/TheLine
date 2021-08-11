using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[RequireComponent(typeof(MazePieceMovable))]
public class MazePiece : MonoBehaviour
{
    public Block[,] Maze => _maze;
    public Vector3 EndPoint { get; private set; }
    private Block[,] _maze;
    private MazePieceMovable _mazePieceMovable;
    private MazePositioner _mazePositioner;
    private List<Ability> _abilities;

    public void BlockInitialize(Block[,] maze)
    {
        _maze = maze;
    }

    public void Initialize(Vector3 endPoint, MazePositioner mazePositioner)
    {
        EndPoint = endPoint;
        _mazePositioner = mazePositioner;
    }

    public void Move()
    {
        _mazePieceMovable.Move();
    }

    public void Disable()
    {
        _mazePositioner.ActiveMazePiece();
        for (int i = 0; i < _abilities.Count; i++)
        {
            _abilities[i].transform.parent = null;
            _abilities[i].gameObject.SetActive(false);
        }
        _abilities.Clear();
        gameObject.SetActive(false);
    }

    public void AddAbility(Ability ability)
    {
        ability.transform.parent = transform;
        _abilities.Add(ability);
    }

    private void Awake()
    {
        _mazePieceMovable = GetComponent<MazePieceMovable>();
        _abilities = new List<Ability>();
    }
}