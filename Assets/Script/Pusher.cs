using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 initPosition;
    Vector3 newPosition;
    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        initPosition = this.transform.position;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Update()
    {
        newPosition = new Vector3(initPosition.x,
            initPosition.y,
            initPosition.z + Mathf.Sin(Time.time));


        Mover();

    }
    public void Mover()
    {
        rb.MovePosition(newPosition);
    }
}
