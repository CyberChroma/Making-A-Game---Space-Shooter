using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public GameObject enemyExplosion;

    private Transform explosionsParent;
    private EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
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
            enemyManager.EnemyDestroyed(transform);
            if (enemyExplosion != null)
            {
                Instantiate(enemyExplosion, transform.position, transform.rotation, explosionsParent);
            }
            Destroy(gameObject);
        }
    }
}
