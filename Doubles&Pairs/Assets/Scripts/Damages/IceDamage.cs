using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDamage : MonoBehaviour
{
    public int m_iceAttack;
    public int m_iceMagic;

    [SerializeField]
    public static int m_icePower = 50;
    [SerializeField]
    public static int m_iceMPower = 40;


    // Start is called before the first frame update
    void Start()
    {
        m_iceAttack = 0;
        m_iceMagic = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (BlueDropDestroy.iceAttackFlag == true)
        {
            m_iceAttack += m_icePower;
        }

        if (BlueDropDestroy.iceMagicFlag == true)
        {
            m_iceMagic += m_iceMPower;
        }
    }
}
