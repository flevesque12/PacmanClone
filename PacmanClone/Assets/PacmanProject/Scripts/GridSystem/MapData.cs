using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 that class is a node map with 0 and 1(0 = Open, 1 = closed or a wall)

 */
public class MapData : MonoBehaviour
{
    public int m_Width = 10;
    public int m_Height = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    int[,] MakeMap()
    {
        int[,] map = new int[m_Width, m_Height];

        for(int y = 0; y < m_Height; y++)
        {
            for(int x = 0; x < m_Width; x++)
            {
                map[x, y] = 0;
            }
        }
        

        return map;
    }
}
