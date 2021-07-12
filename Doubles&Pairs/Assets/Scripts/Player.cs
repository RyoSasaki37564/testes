using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    int m_playerHpMax = 8000;
    public static float m_currentPHp; //現在のプレイヤーのHP
    public static float m_resultPHp; //前のターンのプレイヤーの最終HP

    public Text m_playerHPNum;

    /// <summary>スライダー</summary>
    public Slider m_pHPSlider;

    void Awake()
    {
        m_currentPHp = m_playerHpMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_pHPSlider = GameObject.Find("PlayerHpSlider").GetComponent<Slider>();

        m_playerHPNum.text = m_currentPHp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy.m_currentEHp > 0)
        {

            if (GameManager.turn == GameManager.Turn.EnemyTurn) //敵の攻撃
            {
                Debug.Log("敵の攻撃");
                m_currentPHp -= Enemy.m_enemyAttack;
                m_pHPSlider.value = m_currentPHp;
                m_playerHPNum.text = m_currentPHp.ToString();

                GameManager.turnFlag = true; //ドロップ操作用前提フラグ

                GameManager.turn = GameManager.Turn.CleanUpTurn; // リセットターンに変更
            }

            //if(GameManager.turnFlag == false) //敵の攻撃
            //{
            //    Debug.Log("敵の攻撃");
            //    m_pHPSlider.value = m_currentPHp;
            //    m_currentPHp -= Enemy.m_enemyAttack;
            //    GameManager.turnFlag = true;
            //    GameManager.PlayTimeFlg = true;
            //}

        }
    }
}
