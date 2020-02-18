using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GridSystem
{
    public class Node
    {
        public bool m_IsWalkable;
        public Vector3 m_WorldPosition;
        public int m_GCost;
        public int m_HCost;
        public Node m_ParentNode;

        public int m_FCost
        {
            get
            {
                return m_GCost + m_HCost;
            }
        }

        //the position of the node
        public int m_PosX;
        public int m_PosY;
        public int m_NodeState; //0 = free, 1 = obstacle, 2 = start, 3 = goal, 4 = Pacman

        //constructor
        public Node(int posX, int posY, int state, bool isWalkable)
        {
            this.m_PosX = posX;
            this.m_PosY = posY;
            this.m_NodeState = state;
            this.m_IsWalkable = isWalkable;
        }
    }
}
