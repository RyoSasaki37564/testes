using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEMDropDestroy : MonoBehaviour
{
    AudioSource m_dropsDestroySE;

    // Start is called before the first frame update
    void Start()
    {
        m_dropsDestroySE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!DropsGenerater.dropsDestroyFlag)
        {
            //Debug.Log("鳴った");
            m_dropsDestroySE.PlayOneShot(m_dropsDestroySE.clip);

        }

    }
}
