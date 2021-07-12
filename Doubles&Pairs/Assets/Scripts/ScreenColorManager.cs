using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenColorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0); //平時においては透明
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.turn == GameManager.Turn.EnemyTurn)
        {
            GetComponent<SpriteRenderer>().material.color = new Color32(255, 0, 0, 255); //敵の攻撃で赤くなる
        }



        if (GameManager.turn == GameManager.Turn.ResetTurn)
        {
            GetComponent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0); //戻す
        }
    }
}
