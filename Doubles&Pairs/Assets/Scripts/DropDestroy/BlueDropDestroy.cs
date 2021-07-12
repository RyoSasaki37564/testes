using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDropDestroy : MonoBehaviour
{
    public static bool iceAttackFlag = false;
    public static bool iceMagicFlag = false;
    void Start()
    {
        iceAttackFlag = false;
        iceMagicFlag = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Enemy.m_currentEHp >= 0)
        {
            if (collision.gameObject.tag == "SBlue")
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                this.gameObject.SetActive(false);
                DropsGenerater.dropsDestroyFlag = false;
                iceAttackFlag = true;

                GameManager.SetTurn(GameManager.Turn.PlayerTurn);
            }

            if (collision.gameObject.tag == "CBlue")
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                this.gameObject.SetActive(false);
                DropsGenerater.dropsDestroyFlag = false;
                iceMagicFlag = true;

                GameManager.SetTurn(GameManager.Turn.PlayerTurn);
            }
        }

        
    }
}
