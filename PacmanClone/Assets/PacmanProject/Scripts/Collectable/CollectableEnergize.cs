using System.Collections;
using UnityEngine;

public class CollectableEnergize : MonoBehaviour
{
    public int m_Point = 50;
    private PlayerStats m_PlayerStats;
    private GameManager m_GameManager;
    private Pinky m_Pinky;
    private Inky m_Inky;
    private Clyde m_Clyde;
    private Blinky m_Blinky;
    private SpriteRenderer m_Render;

    // Start is called before the first frame update
    private void Start()
    {
        m_PlayerStats = FindObjectOfType<PlayerStats>();
        m_Pinky = FindObjectOfType<Pinky>();
        m_Inky = FindObjectOfType<Inky>();
        m_Clyde = FindObjectOfType<Clyde>();
        m_Blinky = FindObjectOfType<Blinky>();
        m_Render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_PlayerStats.AddScorePoint(m_Point);
            m_PlayerStats.CountDotEated();

            m_Pinky.IsVulnerable = true;
            m_Blinky.IsVulnerable = true;
            m_Inky.IsVulnerable = true;
            m_Clyde.IsVulnerable = true;

            m_Render.enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(VulnerabilityTimer());
        }
    }

    private IEnumerator VulnerabilityTimer()
    {
        yield return new WaitForSeconds(4);
        m_Pinky.IsVulnerable = false;
        m_Blinky.IsVulnerable = false;
        m_Inky.IsVulnerable = false;
        m_Clyde.IsVulnerable = false;
    }
}