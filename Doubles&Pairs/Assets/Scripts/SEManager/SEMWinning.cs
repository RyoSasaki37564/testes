using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEMWinning : MonoBehaviour
{
    AudioSource m_winningSE;
    private bool m_wSEFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        m_winningSE = GetComponent<AudioSource>();
        m_wSEFlg = false;
    }

    void FixedUpdate()
    {
        if (Enemy.m_currentEHp <= 0)
        {
            m_winningSE.PlayOneShot(m_winningSE.clip);
            m_wSEFlg = true;
        }

        if(GameManager.turn == GameManager.Turn.GameOut)
        {
            m_wSEFlg = false;
        }
    }
}
