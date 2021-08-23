using UnityEngine;
using System.Collections.Generic;

namespace TheLine.Maze
{
    [RequireComponent(typeof(MazePieceMovable))]
    public class MazePiece : MonoBehaviour
    {
        Block[,] maze;
        MazePieceMovable mazePieceMovable;
        MazePositioner mazePositioner;
        List<Ability> abilities;


        public Block[,] Maze => maze;
        public Vector3 EndPoint { get; private set; }


        void Awake()
        {
            mazePieceMovable = GetComponent<MazePieceMovable>();
            abilities = new List<Ability>();
        }


        public void BlockInitialize(Block[,] maze)
        {
            this.maze = maze;
        }

        public void Initialize(Vector3 endPoint, MazePositioner mazePositioner)
        {
            EndPoint = endPoint;
            this.mazePositioner = mazePositioner;
        }

        public void Move()
        {
            mazePieceMovable.Move();
        }

        public void Disable()
        {
            mazePositioner.ActiveMazePiece();
            for (int i = 0; i < abilities.Count; i++)
            {
                abilities[i].transform.parent = null;
                abilities[i].gameObject.SetActive(false);
            }
            abilities.Clear();
            gameObject.SetActive(false);
        }

        public void AddAbility(Ability ability)
        {
            ability.transform.parent = transform;
            abilities.Add(ability);
        }
    }
}