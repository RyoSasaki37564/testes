using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sponer : MonoBehaviour
{
    

    float speed = 2.0f;
    Rigidbody rb;

    public GameObject Kane;

    public GameObject leftWall;

    public GameObject rightWall;

    float leftWallPositionX;

    float rightWallPositionX;

    public GameObject sText;
    UI scoreS;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        leftWallPositionX = leftWall.transform.position.x;

        rightWallPositionX = rightWall.transform.position.x;

        scoreS = sText.GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currentPosition = this.transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x,
                                        leftWallPositionX,
                                        rightWallPositionX);



        float x = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(x, 0, 0);

        rb.velocity = direction * speed;

        if (Input.GetKeyDown("space"))
            
        {
            Instantiate(Kane, this.transform.position, this.transform.rotation);
            scoreS.addScore(-1);
        }

    }
}
