using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_Instance;

    public GameObject m_WinningGamePanel;
    public GameObject m_GameOverPanel;

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else if (m_Instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void InitializeGameOverScreen()
    {
        m_GameOverPanel.SetActive(true);
    }

    public void InitializeWinningScreen()
    {
        m_WinningGamePanel.SetActive(true);
    }
}