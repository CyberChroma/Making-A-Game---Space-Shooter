using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotDestroy : MonoBehaviour
{
    public GameObject enemyShotExplosion;

    private Transform explosionsParent;

    private void Start()
    {
        explosionsParent = GameObject.Find("Particle Systems").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(enemyShotExplosion, transform.position, transform.rotation, explosionsParent);
            Destroy(gameObject);
        }
    }
}
