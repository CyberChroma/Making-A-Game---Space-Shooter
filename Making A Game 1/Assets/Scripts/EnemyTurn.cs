using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour
{

    public float leftMove;
    public float rightMove;
    public float smoothing;
    public bool startRight = true;

    private Rigidbody rb;
    private float dirMultiplier = 1;
    private bool dir = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        dir = startRight;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dir) {
            dirMultiplier = Mathf.Lerp(dirMultiplier, -1, smoothing * Time.deltaTime);
        } else
        {
            dirMultiplier = Mathf.Lerp(dirMultiplier, 1, smoothing * Time.deltaTime);
        }
        if (dir && dirMultiplier < - 0.9f)
        {
            dir = false;
        } else if (!dir && dirMultiplier > 0.9f)
        {
            dir = true;
        }

        if (dirMultiplier > 0) {
            rb.AddForce(transform.right * dirMultiplier * rightMove);
        } else
        {
            rb.AddForce(transform.right * dirMultiplier * leftMove);
        }
    }
}
