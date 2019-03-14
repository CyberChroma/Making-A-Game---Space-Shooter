using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDestroy : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<EnemyScore>())
            {
                other.GetComponent<EnemyScore>().AddScore();
            }
            Destroy(gameObject);
        }
    }
}
