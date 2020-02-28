using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GridSystem
{
    public class CustomGrid
    {
        private int m_Width;
        private int m_Height;
        private float m_CellSize;
        private int[,] m_GridArray;

        public CustomGrid(int width,int height,float cellSize)
        {
            this.m_Width = width;
            this.m_Height = height;
            this.m_CellSize = cellSize;

            m_GridArray = new int[width, height];

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {

                }
            }
        }
    }
}
