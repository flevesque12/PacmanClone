﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinky : MonoBehaviour
{
    #region Variables
    public Transform[] m_Waypoints;
    public int m_Point = 200;
    public float m_Speed = 0.3f;
    private bool m_IsVulnerable = false;
    private int m_CurrentWaypoint = 0;
    private Rigidbody2D m_Rb2d;
    private SpriteRenderer m_Render;
    private PlayerStats m_PlayerStats;

    #endregion
    // Start is called before the first frame update
    private void Start()
    {
        m_Rb2d = GetComponent<Rigidbody2D>();
        m_Render = GetComponent<SpriteRenderer>();
        m_PlayerStats = FindObjectOfType<PlayerStats>();
    }
    private void Update()
    {
        if (m_IsVulnerable)
        {
            m_Render.color = Color.blue;
        }
        else
        {
            m_Render.color = Color.green;
        }
    }

    private void FixedUpdate()
    {
        if (transform.position != m_Waypoints[m_CurrentWaypoint].position)
        {
            Vector2 _position = Vector2.MoveTowards(transform.position, m_Waypoints[m_CurrentWaypoint].position, m_Speed);
            m_Rb2d.MovePosition(_position);
        }
        else
        {
            m_CurrentWaypoint = (m_CurrentWaypoint + 1) % m_Waypoints.Length;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_IsVulnerable == false)
        {
            if (collision.tag == "Player")
            {
                m_PlayerStats.DecreaseLife();
            }
        }

        if (m_IsVulnerable)
        {
            if (collision.tag == "Player")
            {
                m_PlayerStats.AddScorePoint(m_Point);
            }
        }
    }
}