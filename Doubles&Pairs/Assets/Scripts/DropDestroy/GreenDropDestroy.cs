using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDropDestroy : MonoBehaviour
{
    public static bool woodAttackFlag = false;
    public static bool woodMagicFlag = false;

    void Start()
    {
        woodAttackFlag = false;
        woodMagicFlag = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (Enemy.m_currentEHp >= 0)
            {
                if (collision.gameObject.tag == "SGreen")
                {
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    woodAttackFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }

                if (collision.gameObject.tag == "CGreen")
                {
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    woodMagicFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }
            }
        }

    }
}
