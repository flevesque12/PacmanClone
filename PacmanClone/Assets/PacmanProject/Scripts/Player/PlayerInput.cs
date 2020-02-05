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
    }

    private void Move()
    {
        if (m_IsAlive)
        {
            if (Input.GetKey(KeyCode.A))
            {
                m_PlayerDirection = Vector2.left;

                m_CanMove = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                m_PlayerDirection = Vector2.right;

                m_CanMove = true;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                m_PlayerDirection = Vector2.up;

                m_CanMove = true;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                m_PlayerDirection = Vector2.down;

                m_CanMove = true;
            }
        }

        if (m_CanMove)
        {
            m_Rb2d.velocity = m_PlayerDirection * m_PlayerSpeed;
        }
    }
}