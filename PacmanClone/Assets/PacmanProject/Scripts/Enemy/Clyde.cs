using UnityEngine;

public class Clyde : MonoBehaviour
{
    #region Variables

    public Transform[] m_Waypoints;
    public int m_Point = 200;
    public float m_Speed = 0.3f;
    private bool m_IsVulnerable = false;

    public bool IsVulnerable
    {
        get { return this.m_IsVulnerable; }
        set { this.m_IsVulnerable = value; }
    }

    private int m_CurrentWaypoint = 0;
    private Rigidbody2D m_Rb2d;
    private SpriteRenderer m_Render;
    private PlayerStats m_PlayerStats;

    #endregion Variables

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
            m_Render.color = Color.red;
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
                PlayerStats _playerStats = collision.gameObject.GetComponent<PlayerStats>();
                _playerStats.DecreaseLife();
            }
        }

        if (m_IsVulnerable)
        {
            if (collision.tag == "Player")
            {
                PlayerStats _playerStats = collision.gameObject.GetComponent<PlayerStats>();
                _playerStats.AddScorePoint(m_Point);

                ReturnHome();
            }
        }
    }

    private void ReturnHome()
    {
        transform.position = new Vector2(-5.5f, 1.5f);
        m_CurrentWaypoint = 0;
    }
}