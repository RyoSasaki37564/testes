using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutLineOnOff : MonoBehaviour
{
    private bool m_outLineFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        m_outLineFlg = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            if (m_outLineFlg == false)
            {
                GetComponent<Collider2D>().enabled = false;
                StartCoroutine(OutLineSet());
                m_outLineFlg = true;
            }
        }

        
    }
    IEnumerator OutLineSet()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<Collider2D>().enabled = true;
        m_outLineFlg = false;
        GameManager.turn = GameManager.Turn.ResetTurn;
    }
}
