using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    #region Variables

    public int m_PlayerLife = 3;
    public int m_PlayerScore = 0;

    //count all the dots that pacman need to eat to win the game
    private int m_DotCollectableCount = 0;

    private int m_DotEated = 0;

    //get All dot object in the scene to count the dot pacman need to win the game
    private GameObject[] m_DotGameObjectLists;

    public Text m_TxtScore;
    public Text m_TxtBestScore;
    public Text m_TxtLife;

    private bool m_IsColliding;

    #endregion Variables

    // Start is called before the first frame update
    private void Start()
    {
        m_TxtLife.text = m_PlayerLife.ToString();
        m_TxtScore.text = m_PlayerScore.ToString();

        m_DotGameObjectLists = GameObject.FindGameObjectsWithTag("Dot");
        m_DotCollectableCount = m_DotGameObjectLists.Length;
    }

    private void Update()
    {
        if (m_PlayerLife == 0)
        {
            //GameOverScreen();
        }

        if (m_DotEated == m_DotCollectableCount)
        {
            GameWinningScreen();
        }
    }

    private void GameOverScreen()
    {
        GameManager.m_Instance.InitializeGameOverScreen();
        Time.timeScale = 0;
        Destroy(gameObject);
    }

    private void GameWinningScreen()
    {
        GameManager.m_Instance.InitializeWinningScreen();
        m_TxtBestScore.text = m_PlayerScore.ToString();
        Time.timeScale = 0;
    }

    public void AddScorePoint(int scoreValue)
    {
        m_PlayerScore += scoreValue;
        m_TxtScore.text = m_PlayerScore.ToString();
    }

    public void DecreaseLife()
    {
        if (m_PlayerLife >= 0)
        {
            m_PlayerLife--;
            m_TxtLife.text = m_PlayerLife.ToString();
            ReturnStartPosition();
        }
    }

    public void CountDotEated()
    {
        if (m_DotEated <= m_DotCollectableCount)
        {
            m_DotEated++;
        }
    }


    private void ReturnStartPosition()
    {
        transform.position = new Vector2(0f, -3.3f);
    }
}