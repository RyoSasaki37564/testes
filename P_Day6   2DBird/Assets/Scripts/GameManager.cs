using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Text gameStateText;

    GameObject playerRB;

    void Start()
    {
        playerRB = GameObject.Find("Valkyrie");
        gameStateText.text = "はじめい！";
        StartCoroutine(TextReset());
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRB == null)
        {
            gameStateText.text = "お前は絶滅！";
            StartCoroutine(GameOverSet());
        }
    }

    IEnumerator TextReset()
    {
        yield return new WaitForSeconds(1.5f);
        gameStateText.text = "";

    }

    IEnumerator GameOverSet()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("GameOver");
    }
}
