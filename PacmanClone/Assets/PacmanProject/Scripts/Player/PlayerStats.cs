using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int m_PlayerLife = 3;
    public int m_PlayerScore = 0;

    //public Text m_TxtScore;
    //public Text m_TxtLife;

    // Start is called before the first frame update
    private void Start()
    {
      //  m_TxtLife.text = m_PlayerLife.ToString();
        //m_TxtScore.text = m_PlayerScore.ToString();
    }

    public void AddScorePoint(int scoreValue)
    {
        m_PlayerScore += scoreValue;
        //m_TxtScore.text = m_PlayerScore.ToString();
    }

    public int GetScorePoint()
    {
        return this.m_PlayerScore;
    }

    public int GetLifeRemain()
    {
        return this.m_PlayerLife;
    }

    public void DecreaseLife()
    {
        if (this.m_PlayerLife >= 0)
        {
            this.m_PlayerLife--;
            //m_TxtLife.text = m_PlayerLife.ToString();
        }
    }
}
