using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float m_jumpVelocity = 1000.0f; //ジャンプ力

    Rigidbody2D rb2d;

    [SerializeField]
    private Sprite m_deadSprite;

    Animator anim; //アニメーターぶっこんどく
    SpriteRenderer m_renderer; // 死体の絵

    public static bool playFlg = false;

    void Start()
    {
        playFlg = false;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        TouchManager.Began += (info) =>
        {
            rb2d.velocity = Vector2.zero; //落下速度リセット
                rb2d.AddForce(transform.up * m_jumpVelocity, ForceMode2D.Impulse); //上方向に力を加える
            };

        if (transform.position.x < -10f)
        {

            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Wall.scorePoint >= 50)
        {
            Wall.scorePoint -= 50;
        }
        playFlg = true;
        Debug.Log(playFlg);
        StartCoroutine(BackToHere());
        anim.enabled = false;
        m_renderer = GetComponent<SpriteRenderer>();
        m_renderer.sprite = m_deadSprite;
    }

    IEnumerator BackToHere()
    {
        yield return new WaitForSeconds(1.0f);
        anim.enabled = true;
        playFlg = false;
        Debug.Log(playFlg);
    }
}
