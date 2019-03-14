using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    public float yRot = 0;

    private CameraTurn cameraTurn;

    // Start is called before the first frame update
    void Start()
    {
        cameraTurn = FindObjectOfType<CameraTurn>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraTurn.StartTurn(yRot);
            Destroy(gameObject);
        }
    }
}
