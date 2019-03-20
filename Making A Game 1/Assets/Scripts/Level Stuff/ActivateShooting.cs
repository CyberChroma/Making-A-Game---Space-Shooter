using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShooting : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyShoot>() != null)
        {
            other.GetComponent<EnemyShoot>().enabled = true;
        } else if (other.CompareTag("Player Shot"))
        {
            Destroy(other.gameObject);
        }
    }
}
