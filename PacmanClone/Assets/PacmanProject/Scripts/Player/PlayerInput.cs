using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    #region Variables

    public float m_PlayerSpeed = 4.0f;

    private Rigidbody2D m_Rb2d;
    private Vector2 m_PlayerDirection = Vector2.zero;
    private bool m_IsAlive = true;
    private bool m_CanMove = false;

    #endregion Variables

    // Start is called before the first frame update
    private void Start()
    {
        m_Rb2d = GetComponent<Rigidbody2D>();
        m_PlayerDirection = transform.position;
    }

    private void FixedUpdate()
    {
        Move();
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, m_PlayerDirection, 1.0f);
        Debug.DrawRay(transform.position, m_PlayerDirection,Color.green);
        Debug.Log(_hit.collider.name);
    }

    private void Move()
    {
        if (m_IsAlive)
        {
            if (Input.GetKey(KeyCode.A))
            {
                m_PlayerDirection = Vector2.left;
                //m_Rb2d.velocity = Vector2.left * m_PlayerSpeed;
                m_CanMove = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                m_PlayerDirection = Vector2.right;
                //m_Rb2d.velocity = Vector2.right * m_PlayerSpeed;
                m_CanMove = true;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                m_PlayerDirection = Vector2.up;
                //m_Rb2d.velocity = Vector2.up * m_PlayerSpeed;
                m_CanMove = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                m_PlayerDirection = Vector2.down;

                //m_Rb2d.velocity = Vector2.down * m_PlayerSpeed;
                m_CanMove = true;
            }
        }

        if (m_CanMove)
        {
            m_Rb2d.velocity = m_PlayerDirection * m_PlayerSpeed;
        }
    }

    private bool IsValidDirection(Vector2 direction)
    {
        Vector2 _position = transform.position;

        RaycastHit2D _hit = Physics2D.Raycast(_position, direction);
        Debug.DrawRay(_position, direction, Color.green);
        return _hit.collider.name == "Wall";
    }

    //no physic it dont work
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            m_CanMove = false;
            Debug.Log("Collide a wall");
        }
    }
}
