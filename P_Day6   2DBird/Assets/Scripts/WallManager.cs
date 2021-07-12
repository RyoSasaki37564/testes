using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallManager : MonoBehaviour
{
    [SerializeField]
    private float m_interval = 2.0f;

    float m_nextSpawnTime;

    [SerializeField]
    GameObject[] walls;

    [SerializeField]
    GameObject m_spawner;

    [SerializeField]
    Text scoreText;

    void Update()
    {

        scoreText.text = ("score:" + Wall.scorePoint);

        if (m_nextSpawnTime < Time.timeSinceLevelLoad)
        {
            m_nextSpawnTime = Time.timeSinceLevelLoad + m_interval;
            int m_id = Random.Range(0, walls.Length);
            GameObject m_obj = (GameObject)Instantiate(walls[m_id],
                m_spawner.transform.position,
                m_spawner.transform.rotation);
        }
        
    }
}
