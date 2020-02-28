using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridSystem
{
    public class NodeView : MonoBehaviour
    {

        public GameObject m_TileView;

        [Range(0, 0.5f)]
        public float m_BorderSize = 0.15f;

        Node m_Node;
        
        public void InitNodeTile(Node node)
        {
            if (m_TileView != null)
            {
                gameObject.name = "Node (" + node.m_PosX + " , " + node.m_PosY + ")";
                gameObject.transform.position = node.m_Position;
                m_TileView.transform.localScale = new Vector3(1f - m_BorderSize, 1f - m_BorderSize, 1f);
            }
        }

        void ColorNode(Color color, GameObject gObject)
        {
            if (gameObject != null)
            {
                SpriteRenderer _renderer = gObject.GetComponent<SpriteRenderer>();

                if (_renderer != null)
                {
                    _renderer.color = color;
                }
            }
        }

        public void ColorNode(Color color)
        {
            ColorNode(color, m_TileView);
        }
    }
}