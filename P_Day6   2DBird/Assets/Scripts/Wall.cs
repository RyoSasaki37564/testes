using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    float m_wallSpeed = 0.04f;

    public static int scorePoint = 0;

    GameObject playerObj;

    private void Start()
    {
        playerObj = GameObject.Find("Valkyrie");
    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x - m_wallSpeed,
            transform.position.y,
            transform.position.z);

        if(playerObj !=null &&  transform.position.x < -10f)
        {
            Destroy(this.gameObject);
            scorePoint += 100;
        }
    }
    
}
