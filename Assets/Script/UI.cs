using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//スコアテキスト

public class UI : MonoBehaviour
{
    public int initScore;
    int currentScore;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {

        currentScore = initScore;
        scoreText = this.GetComponent<Text>();

        printScore(initScore);

    }

    public void addScore(int n)
    {
        currentScore += n;
        printScore(currentScore);

    }

    void printScore(int n)
    {
        scoreText.text = n.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
