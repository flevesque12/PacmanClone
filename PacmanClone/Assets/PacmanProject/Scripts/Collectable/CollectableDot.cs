using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableDot : MonoBehaviour
{
    public int m_Point = 10;
    private PlayerStats m_PlayerStats;

    private void Start()
    {
        m_PlayerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_PlayerStats.AddScorePoint(m_Point);
            m_PlayerStats.CountDotEated();
            Destroy(this.gameObject);
        }

    }
}
