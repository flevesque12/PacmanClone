using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GridSystem
{
    public class GridSytem : MonoBehaviour {

        public GameObject m_TopRightGridPoint, m_BottomLeftGridPoint;

        //Number of the cells in the grid
        public int m_AmountVerticalCells, m_AmountHorizontalCells;


        public int m_CellWidth = 1;
        public int m_CellHeight = 1;

        //grid info
        int m_StartX, m_StartY;

        int m_EndX, m_EndY;


        public float m_NodeSize;


        Node[,] m_GridNodes;

        public List<Node> m_path;
        public LayerMask m_Unwalkable;

        private void Awake()
        {
            CreateGrid();
        }

        public void CreateGrid()
        {
            m_StartX = (int)m_BottomLeftGridPoint.transform.position.x;
            m_StartY = (int)m_BottomLeftGridPoint.transform.position.y;

            m_EndX = (int)m_TopRightGridPoint.transform.position.x;
            m_EndY = (int)m_TopRightGridPoint.transform.position.y;

            m_AmountHorizontalCells = (int)((m_EndX - m_StartX) / m_CellWidth);
            m_AmountVerticalCells = (int)((m_EndY - m_StartY) / m_CellHeight);

            m_GridNodes = new Node[m_AmountHorizontalCells + 1, m_AmountVerticalCells + 1];

            UpdateGrid();
        } 

        void UpdateGrid()
        {
            for(int x = 0;x <= m_AmountHorizontalCells; x++)
            {
                for(int y = 0; y <= m_AmountVerticalCells; y++)
                {
                    //bool walkable = !Physics.CheckSphere(new Vector3(m_StartX + x, m_StartY + y, 0f), 0.4f, m_Unwalkable);
                    bool walkable = Physics2D.OverlapCircle(new Vector3(m_StartX + x, m_StartY + y, 0f), 0.4f, m_Unwalkable);
                    m_GridNodes[x, y] = new Node(x, y, NodeType.Open, walkable);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(((m_EndX - m_StartX) / m_CellWidth), ((m_EndY - m_StartY) / m_CellHeight), 0f));

            if(m_GridNodes != null)
            {
                foreach(Node node in m_GridNodes)
                {
                    Gizmos.color = (node.m_IsWalkable) ? Color.white : Color.red;
                    //Gizmos.DrawWireCube(new Vector3(m_StartX + node.m_PosX, m_StartY + node.m_PosY, 0f), new Vector3(0.8f, 0.8f, 0.8f));
                    Gizmos.DrawWireSphere(new Vector3(m_StartX + node.m_PosX, m_StartY + node.m_PosY, 0f), 0.4f);
                }
            }
        }

    }
}