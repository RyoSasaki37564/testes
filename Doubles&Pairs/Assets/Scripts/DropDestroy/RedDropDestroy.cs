using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDropDestroy : MonoBehaviour
{
    public static bool fireAttackFlag = false;
    public static bool fireMagicFlag = false;

    void Start()
    {
        fireAttackFlag = false;
        fireMagicFlag = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (Enemy.m_currentEHp >= 0)
            {
                if (collision.gameObject.tag == "SRed")
                {
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    fireAttackFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }

                if (collision.gameObject.tag == "CRed")
                {
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    fireMagicFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }
            }
        }
    }
}
