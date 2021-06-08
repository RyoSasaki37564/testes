using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saucer : MonoBehaviour
{

    public GameObject scoreText;
    UI scoreS; 
    AudioSource getSE;

    private void Start()
    {
        scoreS = scoreText.GetComponent<UI>();
        getSE= GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.tag == "Kane") 
        {
            Destroy(collision.gameObject);
            scoreS.addScore(2);
            getSE.PlayOneShot(getSE.clip);

        }

    }


}
