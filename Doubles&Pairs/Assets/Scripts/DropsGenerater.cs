using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropsGenerater : MonoBehaviour
{
    [SerializeField] 
    private List<GameObject> m_drop = new List<GameObject>();      //ドロップ　6種入れる
    [SerializeField]
    private List<GameObject> m_genePosition = new List<GameObject>();      //ドロップ生成位置 通常盤面では6個つくる
    [SerializeField]
    public List<GameObject> m_startingDrops = new List<GameObject>();   //初期生成ドロップ おいおいパターンを増やす
    [SerializeField]
    public GameObject m_startPosition;

    private int m_pattern = (6-1)*(6/2);
    //生成位置パターン数(マジックナンバー使用中！ 偶数の場合のみ成立する式!)　生成位置の数*(生成位置の数/2)
    private int m_hole;
    //生成位置用の乱数

    private int m_caster1;   private int m_caster2;
    //生成されるドロップを決める乱数 二つずつ消えるルールなので、二つずつ生成のため1と2がある。(2個以上でも消えちゃうのどうしよう)

    private int m_startPattern;
    //初期生成盤面を決める乱。なお現在は１パターンのみ。

    static public bool dropsDestroyFlag = true;    //ドロップ消滅判定用フラグ   

    private bool m_resetterFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        dropsDestroyFlag = true;

        m_startPattern = Random.Range(0,m_startingDrops.Count);

        StartCoroutine("GameStart");

        m_resetterFlg = false;

    }

    // Update is called once per frame
    void Update()
    {

        m_hole = Random.Range(0, m_pattern);
        m_caster1 = Random.Range(0, m_drop.Count);
        m_caster2 = Random.Range(0, m_drop.Count);


        //ランダムドロップ生成  内部構造、原始的手法につき短縮できる式が見つかれば改修を(メソッド化？)
        if (GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (!dropsDestroyFlag) //ドロップを消したら
            {
                dropsDestroyFlag = false;
                m_resetterFlg = false; //リセット処理の準備

                if (GameManager.gameSetFlag)
                {
                    if (m_hole == 0)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[0].transform.position,
                            m_genePosition[0].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[1].transform.position,
                            m_genePosition[1].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 1)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[0].transform.position,
                            m_genePosition[0].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[2].transform.position,
                            m_genePosition[2].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 2)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[0].transform.position,
                            m_genePosition[0].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[3].transform.position,
                            m_genePosition[3].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 3)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[0].transform.position,
                            m_genePosition[0].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[4].transform.position,
                            m_genePosition[4].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 4)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[0].transform.position,
                            m_genePosition[0].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[5].transform.position,
                            m_genePosition[5].transform.rotation);

                        dropsDestroyFlag = true;
                    }


                    else if (m_hole == 6)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[1].transform.position,
                            m_genePosition[1].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[2].transform.position,
                            m_genePosition[2].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 7)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[1].transform.position,
                            m_genePosition[1].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[3].transform.position,
                            m_genePosition[3].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 8)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[1].transform.position,
                            m_genePosition[1].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[4].transform.position,
                            m_genePosition[4].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 9)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[1].transform.position,
                            m_genePosition[1].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[5].transform.position,
                            m_genePosition[5].transform.rotation);

                        dropsDestroyFlag = true;
                    }


                    else if (m_hole == 10)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[2].transform.position,
                            m_genePosition[2].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[3].transform.position,
                            m_genePosition[3].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 11)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[2].transform.position,
                            m_genePosition[2].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[4].transform.position,
                            m_genePosition[4].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 12)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[2].transform.position,
                            m_genePosition[2].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[5].transform.position,
                            m_genePosition[5].transform.rotation);

                        dropsDestroyFlag = true;
                    }


                    else if (m_hole == 13)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[3].transform.position,
                            m_genePosition[3].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[4].transform.position,
                            m_genePosition[4].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                    else if (m_hole == 14)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[3].transform.position,
                            m_genePosition[3].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[5].transform.position,
                            m_genePosition[5].transform.rotation);

                        dropsDestroyFlag = true;
                    }


                    else if (m_hole == 15)
                    {
                        Instantiate(m_drop[m_caster1],
                            m_genePosition[4].transform.position,
                            m_genePosition[4].transform.rotation);

                        Instantiate(m_drop[m_caster2],
                            m_genePosition[5].transform.position,
                            m_genePosition[5].transform.rotation);

                        dropsDestroyFlag = true;
                    }
                }
            }

        }

        if (GameManager.turn == GameManager.Turn.ResetTurn) //リセット処理
        {
            if(m_resetterFlg == false)
            {
                StartCoroutine(GameStart());
                dropsDestroyFlag = true;
                GameManager.turn = GameManager.Turn.InputTurn;
                m_resetterFlg = true;//1回だけ再生するための即切りフラグ

            }
        }
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1.0f);

        Instantiate(m_startingDrops[m_startPattern],
            m_startPosition.transform.position,
            m_startPosition.transform.rotation);
    }
}
