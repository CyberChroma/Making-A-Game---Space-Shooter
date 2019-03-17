using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDestroy : MonoBehaviour
{
    public GameObject playerShotExplosion;

    private Transform explosionsParent;

    private void Start()
    {
        explosionsParent = GameObject.Find("Particle Systems").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<EnemyScore>())
            {
                other.GetComponent<EnemyScore>().AddScore();
            }
            Instantiate(playerShotExplosion, transform.position, transform.rotation, explosionsParent);
            Destroy(gameObject);
        }
    }
}
