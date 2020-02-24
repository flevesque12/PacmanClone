using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GridSystem
{
    public enum NodeType
    {
        Open = 0,
        Blocked = 1,
        Start = 2,
        Goal = 3,
        Pacman = 4
    }

    public class Node
    {
        public bool m_IsWalkable;
        public Vector3 m_Position;
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
        public int m_PosX = -1;
        public int m_PosY = -1;
        //public int m_NodeState; //0 = free, 1 = obstacle, 2 = start, 3 = goal, 4 = Pacman
        public NodeType m_NodeType = NodeType.Open;

        //constructor
        public Node(int posX, int posY, NodeType nodeType, bool isWalkable)
        {
            this.m_PosX = posX;
            this.m_PosY = posY;
            this.m_NodeType = nodeType;
            this.m_IsWalkable = isWalkable;
        }
        
        
        public void Reset()
        {
            m_ParentNode = null;
        } 

        public TextMesh CreateWorldTextMesh(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("WorldText", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);

            TextMesh textMesh = gameObject.GetComponent<TextMesh>();

            return textMesh;
        }
    }


    
}
