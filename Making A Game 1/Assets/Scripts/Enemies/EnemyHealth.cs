using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public GameObject enemyExplosion;

    private Transform explosionsParent;
    private PickupManager pickupManager;

    // Start is called before the first frame update
    void Start()
    {
        pickupManager = FindObjectOfType<PickupManager>();
        explosionsParent = GameObject.Find("Particle Systems").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Shot"))
        {
            pickupManager.EnemyDestroyed(transform);
            if (enemyExplosion != null)
            {
                Instantiate(enemyExplosion, transform.position, transform.rotation, explosionsParent);
            }
            Destroy(gameObject);
        }
    }
}
