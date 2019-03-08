using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int h = 0;
        int v = 0;
        if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            h = 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            v = 1;
        }
        else if (Input.GetKey(KeyCode.S)) {
            v = -1;
        }
        Vector3 moveVector = Vector3.right * h + Vector3.forward * v;
        rb.AddForce(moveVector * speed);
    }
}
