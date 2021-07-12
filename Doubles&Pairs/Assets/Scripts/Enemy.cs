using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Enemy : MonoBehaviour
{
    //シリアライズでCSVファイルをドラッグアンドドロップ。そしてこれを入れたオブジェクトをボタンの窓に持ってって簡単読み込み。
    [SerializeField] TextAsset m_csv = default;

    public int m_enemyHpMax = 1; //敵最大体力
    public float m_enemyPower; //敵攻撃力
    [SerializeField]
    Text m_enemyName; //敵の名前

    public static int m_currentEHp; //現在の敵のHP

    public Text m_enemyHPNum; //敵体力の表示

    public Slider m_eHPSlider; //敵体力のバー

    public static float m_enemyAttack; //敵攻撃力

    public string[,] m_enemyMasterData; //そのクエストの敵データを二次元配列化

    public int m_battleCountNum; //そのクエストにおける戦闘回数

    private int m_nextBattleReader = 0;

    StringReader er;

    void Awake()
    {
        er = new StringReader(m_csv.text);//今回のみそ。CVSを1次元配列として読み込んだ後、さらに２次元配列に落とし込む。

        m_battleCountNum = int.Parse(er.ReadLine()); //最初に読み込むのはそのステージでの戦闘回数

        m_enemyMasterData = new string[m_battleCountNum, 4];

        if (er != null)
        {

            for (var i = 0; i < m_battleCountNum; i++)
            {
                var line = er.ReadLine(); //2行目からはステージのデータを読み込む。
                string[] m_eStatus = line.Split(',');

                m_enemyMasterData[i, 0] = m_eStatus[0]; //そして見込んだデータは２次元配列化。
                m_enemyMasterData[i, 1] = m_eStatus[1];
                m_enemyMasterData[i, 2] = m_eStatus[2];
                m_enemyMasterData[i, 3] = m_eStatus[3];

                Debug.Log(m_enemyMasterData[i, 0]);
                Debug.Log(m_enemyMasterData[i, 1]);
                Debug.Log(m_enemyMasterData[i, 2]);
                Debug.Log(m_enemyMasterData[i, 3]);
            }
        }

        m_enemyName.text = m_enemyMasterData[0, 1];

        m_enemyHpMax = int.Parse(m_enemyMasterData[0, 2]);
        m_eHPSlider.maxValue = m_enemyHpMax;

        m_enemyPower = int.Parse(m_enemyMasterData[0, 3]);

        m_currentEHp = m_enemyHpMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_eHPSlider = GameObject.Find("EnemyHpSlider").GetComponent<Slider>();

        m_enemyHPNum.text = m_currentEHp.ToString();

        m_enemyAttack = m_enemyPower;
    }

    // Update is called once per frame
    void Update()
    {
        
        m_eHPSlider.value = m_currentEHp;

        if (RedDropDestroy.fireAttackFlag == true)
        {
            m_currentEHp -= FireDamage.m_firePower;
            m_enemyHPNum.text = m_currentEHp.ToString();

            RedDropDestroy.fireAttackFlag = false;
        }
        if (RedDropDestroy.fireMagicFlag == true)
        {
            m_currentEHp -= FireDamage.m_fireMPower;
            m_enemyHPNum.text = m_currentEHp.ToString();

            RedDropDestroy.fireMagicFlag = false;
        }


        if(BlueDropDestroy.iceAttackFlag == true)
        {
            m_currentEHp -= IceDamage.m_icePower;
            m_enemyHPNum.text = m_currentEHp.ToString();

            BlueDropDestroy.iceAttackFlag = false;
        }
        if (BlueDropDestroy.iceMagicFlag == true)
        {
            m_currentEHp -= IceDamage.m_iceMPower;
            m_enemyHPNum.text = m_currentEHp.ToString();

            BlueDropDestroy.iceMagicFlag = false;
        }


        if (GreenDropDestroy.woodAttackFlag == true)
        {
            m_currentEHp -= WoodDamage.m_woodPower;
            m_enemyHPNum.text = m_currentEHp.ToString();

            GreenDropDestroy.woodAttackFlag = false;
        }
        if (GreenDropDestroy.woodMagicFlag == true)
        {
            m_currentEHp -= WoodDamage.m_woodMPower;
            m_enemyHPNum.text = m_currentEHp.ToString();

            GreenDropDestroy.woodMagicFlag = false;
        }

        if(m_currentEHp <= 0)
        {
            m_nextBattleReader++;
        }

        if(GameManager.turn == GameManager.Turn.NextBattleTurn)
        {
            m_enemyName.text = m_enemyMasterData[m_nextBattleReader, 1];

            m_enemyHpMax = int.Parse(m_enemyMasterData[m_nextBattleReader, 2]);
            m_eHPSlider.maxValue = m_enemyHpMax;

            m_enemyPower = int.Parse(m_enemyMasterData[m_nextBattleReader, 3]);

            m_currentEHp = m_enemyHpMax;
            m_enemyHPNum.text = m_currentEHp.ToString();

            if (m_nextBattleReader == m_battleCountNum)
            {
                GameManager.gameSetFlag = false;
                StartCoroutine(ResultSet());
            }
            else
            {
                StartCoroutine(NextBattleSet());
            }
        }

    }

    IEnumerator ResultSet()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Result");
    }

    IEnumerator NextBattleSet()
    {
        yield return new WaitForSeconds(2.0f);
        GameManager.turn = GameManager.Turn.CleanUpTurn;
    }
}
