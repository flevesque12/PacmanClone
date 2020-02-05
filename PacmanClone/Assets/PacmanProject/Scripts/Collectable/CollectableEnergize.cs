using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableEnergize : MonoBehaviour
{
    public int m_Point = 50;
    private PlayerStats m_PlayerStats;
    private GameManager m_GameManager;

    // Start is called before the first frame update
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
