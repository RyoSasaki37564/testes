using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVLoader : MonoBehaviour
{
    //CSV読み込みのひな型

    //[SerializeField] TextAsset m_csv = default; //シリアライズでCSVファイルをドラッグアンドドロップ。そしてこれを入れたオブジェクトをボタンの窓に持ってって簡単読み込み。


    //public void Test() //原型。
    //{
    //    StringReader sr = new StringReader(m_csv.text);
        
    //    while (true)
    //    {
    //        var line = sr.ReadLine();

    //        if (line != null)
    //        {
    //            var cells = line.Split(',');

    //            foreach(var cell in cells)
    //            {
    //                Debug.Log(cell);
    //            }
    //        }
    //        else
    //        {
    //            break;
    //        }
    //    }
    //}

    //public void EnemyStatusMastar() //今回のみそ。CVSを1次元配列として読み込んだ後、さらに２次元配列に落とし込む。
    //{
    //  StringReader er = new StringReader(m_csv.text);

    //    var m_battleCountNum = er.ReadLine(); //最初に読み込むのはそのステージでの戦闘回数

    //    string[,] m_enemyMasterData = new string[int.Parse(m_battleCountNum), 4];

    //    if (er != null)
    //    {
            
    //        for (var i = 0; i < int.Parse(m_battleCountNum); i++)
    //        {
    //            var line = er.ReadLine(); //2行目からはステージのデータを読み込む。
    //            string[] m_eStatus = line.Split(',');

    //            m_enemyMasterData[i, 0] = m_eStatus[0]; //そして見込んだデータは２次元配列化。
    //            m_enemyMasterData[i, 1] = m_eStatus[1];
    //            m_enemyMasterData[i, 2] = m_eStatus[2];
    //            m_enemyMasterData[i, 3] = m_eStatus[3];

    //            Debug.Log(m_enemyMasterData[i, 0]);
    //            Debug.Log(m_enemyMasterData[i, 1]);
    //            Debug.Log(m_enemyMasterData[i, 2]);
    //            Debug.Log(m_enemyMasterData[i, 3]);

    //        }

    //    }
    //}
}
