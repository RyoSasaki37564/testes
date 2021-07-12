using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timerText; //操作時間のUI
    public float totalTime;
    int iii; //操作時間の打ち止め。－秒の表記封じ
    int seconds;

    GameObject m_enemyMastarObj; //エネミーマスターデータを扱うためにエネミーを取得


    public enum Turn
    {
        InputTurn,//入力待ち
        PlayerTurn,//入力中ターン
        EnemyTurn,//敵の攻撃
        CleanUpTurn,  //残存ドロップの廃棄処理
        ResetTurn,  //ドロップ再配置
        NextBattleTurn, //次の戦闘の受け取りターン
        GameOut,  //ゲーム外状態。ゲームセットとゲームスタートの橋渡し役。
    }
    public static Turn turn;

    public Text gst; //ゲームの始めと終わりを告げる。デフォではスタンバイとか書かれてる。
    public static bool gameSetFlag = true; //  ゲーム終了判定
    public static bool PlayTimeFlg = true; //操作時間カウントダウン用コルーチンを単発呼びするためのフラグ シーンのはじめか敵ターンにtrueを返す
    public static bool turnFlag = true; //　操作の可否

    //[SerializeField] GameObject m_player;

    /// <summary>前のターンの敵の最終体力</summary>
    public int m_resultEHp;

    // Start is called before the first frame update
    void Awake()
    {
        m_enemyMastarObj = GameObject.Find("EnemyObj"); //エネミーマスターデータを扱うためにエネミーを取得


        iii = (int)totalTime; //カウントのストッパー

        //Player player = m_player.GetComponent<Player>(); // staticを通さないクラス入手の仕方

        gameSetFlag = true;
        turnFlag = true;
        PlayTimeFlg = true;
        gst.text = "はじめい！";
        StartCoroutine(GstUI());

        turn = Turn.GameOut;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (turn)
        {
            case Turn.InputTurn: // 操作待ちの状態
                totalTime = iii;
                seconds = (int)totalTime;
                timerText.text = "Play!";
                m_resultEHp = Enemy.m_currentEHp;
                Player.m_resultPHp = Player.m_currentPHp;
                break;
            case Turn.PlayerTurn:// プレイヤーが動かしている時の状態
                if (PlayTimeFlg)
                {
                    StartCoroutine(PlayTime()); // updateでうごいてるからバグる
                    PlayTimeFlg = false;
                }
                totalTime -= Time.deltaTime;
                seconds = (int)totalTime;
                timerText.text = "操作時間 : " + seconds.ToString();
                break;
            case Turn.EnemyTurn: // 敵が攻撃してる状態
                StopCoroutine(PlayTime());
                PlayTimeFlg = true;
                timerText.text = "敵の攻撃！";
                break;

            case Turn.NextBattleTurn:
                PlayTimeFlg = false;
                StopCoroutine(PlayTime());
                gst.text = "ぶっとばし☆";
                timerText.text = "";
                seconds = (int)totalTime;
                break;

            case Turn.CleanUpTurn:
                break;
            case Turn.ResetTurn:
                Player.m_resultPHp = Player.m_currentPHp;
                m_resultEHp = Enemy.m_currentEHp;
                totalTime = iii;
                seconds = (int)totalTime;
                gst.text = "";
                timerText.text = "ぷれい！";
                break;
            
            case Turn.GameOut:
                totalTime = iii;
                seconds = (int)totalTime;
                timerText.text = "PLAY!";
                break;
            default:
                break;
        }

        if (Enemy.m_currentEHp <= 0)
        {
                totalTime = iii;
                seconds = (int)totalTime;
                gst.text = "いぇーい";
                timerText.text = "うぃん!";
                turn = Turn.NextBattleTurn;
        }

        if(Player.m_currentPHp <= 0)
        {
            gameSetFlag = false;
            totalTime = iii;
            seconds = (int)totalTime;
            gst.text = "ぶちころされました☆";
            timerText.text = "ぐぇえ！";
            StartCoroutine(ResultSet());
            turn = Turn.GameOut;
        }

        if (turn == Turn.GameOut) //ゲーム外ターン。ゲーム終了処理をしたのちインプットに戻るだけのターン。
        {
            turn = Turn.InputTurn;
        }
    }
    public static void SetTurn(Turn t)
    {
        if (turn != Turn.EnemyTurn) // エネミーターン以外の時
        {
            turn = t;
        }
    }

    IEnumerator GstUI()
    {
        yield return new WaitForSeconds(2.0f);
        gst.text = "";
    }

    IEnumerator PlayTime()
    {
        Debug.Log("StartPlayTime");
        yield return new WaitForSeconds(totalTime);
        turnFlag = false;
        turn = Turn.EnemyTurn;

        yield break;
    }

    IEnumerator ResultSet() 
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Result");
    }
}
