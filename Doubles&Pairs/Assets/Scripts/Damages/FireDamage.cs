using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    public int m_fireAttack;
    public int m_fireMagic;

    [SerializeField]
    public static int m_firePower = 50;
    [SerializeField]
    public static int m_fireMPower = 40;


    // Start is called before the first frame update
    void Start()
    {
        m_fireAttack = 0;
        m_fireMagic = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RedDropDestroy.fireAttackFlag == true)
        {
            m_fireAttack += m_firePower;
        }

        if (RedDropDestroy.fireMagicFlag == true)
        {
            m_fireMagic += m_fireMPower;
        }
    }
}
