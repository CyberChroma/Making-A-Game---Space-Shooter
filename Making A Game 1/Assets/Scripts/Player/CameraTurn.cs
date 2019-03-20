using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurn : MonoBehaviour
{

    public float smoothing;

    private float yRotTarget;
    private bool isTurning = false;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        yRotTarget = transform.rotation.eulerAngles.y;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTurning)
        {
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(0, yRotTarget, 0)), smoothing * Time.deltaTime));
            if (Mathf.Abs(rb.rotation.eulerAngles.y - yRotTarget) < 0.5f) {
                rb.MoveRotation(Quaternion.Euler(new Vector3(0, yRotTarget, 0)));
                isTurning = false;
            }
        }
    }

    public void StartTurn (float yRot)
    {
        yRotTarget = yRot;
        isTurning = true;
    }
}
