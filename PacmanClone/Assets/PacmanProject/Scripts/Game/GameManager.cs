using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject[] m_DotGameObjectLists;
    private int m_DotCollectableCount = 0;
    private int m_DotEated = 0;

    // Start is called before the first frame update
    private void Start()
    {
        m_DotGameObjectLists = GameObject.FindGameObjectsWithTag("Dot");
        m_DotCollectableCount = m_DotGameObjectLists.Length;
        Debug.Log("" + m_DotCollectableCount);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void CountPlayerDotEaten()
    {
        if (m_DotEated <= m_DotCollectableCount)
        {
            m_DotEated++;
        }
        else
        {
            Debug.Log("All dot are eated finish the stage");
        }
    }
}
