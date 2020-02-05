using System.Collections;
using System.Collections.Generic;
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
        else if(m_Instance != null)
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
    /*
    public void CountPlayerDotEaten()
    {      
        if(m_DotEated == m_DotCollectableCount)
        {
            m_GameOverPanel.SetActive(true);
            //Debug.Log(m_DotEated);
        }
        else
        {
            m_DotEated++;
            //Debug.Log(m_DotEated + "eaty");
        }

        
        if (m_DotEated < m_DotCollectableCount)
        {
            m_DotEated++;
            Debug.Log(m_DotEated);
        }
        else
        {
            Debug.Log("All dot are eated finish the stage");
            m_GameOverPanel.SetActive(true);
        }*/
    //}

    //ps he suposed to know when the player has depleted all his life and if he eated all the dots
}
