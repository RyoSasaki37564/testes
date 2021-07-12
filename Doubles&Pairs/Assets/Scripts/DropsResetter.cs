using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//このスクリプトでやりたかったことはジェネレーターに書けてある。このスクリプトはその内容の保存目的。

public class DropsResetter : MonoBehaviour
{
    //クリンナップ完了後ドロップの初期配置を実行する
    GameObject m_resetLoader; //DropsGeneraterが入ってるメインカメラの入れ物
    DropsGenerater m_settingDrops; //DropsGeneraterの入れ物

    List<GameObject> m_resettingDrops; // = m_settingDrops.m_startingDrops;
    int m_resetPattern; // = m_settingDrops.m_startPattern;
    GameObject m_resetPosition; // = m_settingDrops.m_startPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_resetLoader = GameObject.Find("MainCamera");
        m_settingDrops = m_resetLoader.GetComponent<DropsGenerater>();

        m_resettingDrops = m_settingDrops.m_startingDrops;
        //m_resetPattern = m_settingDrops.m_startPattern;
        m_resetPosition = m_settingDrops.m_startPosition;
    }

    void Update()
    {
        
        if (GameManager.turn == GameManager.Turn.ResetTurn)
        {
            Instantiate(m_resettingDrops[m_resetPattern],
            m_resetPosition.transform.position,
            m_resetPosition.transform.rotation);

            GameManager.turn = GameManager.Turn.InputTurn;
        }
    }

    ///ジェネレーターで使う///
    //if (GameManager.turn == GameManager.Turn.ResetTurn)
      //  {
        //    StartCoroutine(GameStart());
   // dropsDestroyFlag = true;
     //      GameManager.turn = GameManager.Turn.InputTurn;
       // }
}
