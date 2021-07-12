using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDamage : MonoBehaviour
{
    public int m_woodAttack;
    public int m_woodMagic;

    [SerializeField]
    public static int m_woodPower = 50;
    [SerializeField]
    public static int m_woodMPower = 40;


    // Start is called before the first frame update
    void Start()
    {
        m_woodAttack = 0;
        m_woodMagic = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RedDropDestroy.fireAttackFlag == true)
        {
            m_woodAttack += m_woodPower;
        }

        if (RedDropDestroy.fireMagicFlag == true)
        {
            m_woodMagic += m_woodMPower;
            m_woodMagic += m_woodMPower;
        }
    }
}
