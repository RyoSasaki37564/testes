using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoder : MonoBehaviour
{
    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void GoMainGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
