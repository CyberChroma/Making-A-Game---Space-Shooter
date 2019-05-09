using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

    public GameObject shieldPickup;
    public GameObject gunPickup;
    public int pickupEnemiesMin = 3;
    public int pickupEnemiesMax = 6;

    private int pickupEnemiesLeft;
    private Transform shotsParent;

    // Start is called before the first frame update
    void Start()
    {
        pickupEnemiesLeft = Random.Range(pickupEnemiesMin, pickupEnemiesMax + 1);
        shotsParent = GameObject.Find("Shots").transform;
    }

    public void EnemyDestroyed (Transform enemyTransform)
    {
        pickupEnemiesLeft--;
        if (pickupEnemiesLeft == 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                if (shieldPickup)
                {
                    Instantiate(shieldPickup, enemyTransform.position, enemyTransform.rotation, shotsParent);
                }
            }
            else
            {
                if (gunPickup)
                {
                    Instantiate(gunPickup, enemyTransform.position, enemyTransform.rotation, shotsParent);
                }
            }
            pickupEnemiesLeft = Random.Range(pickupEnemiesMin, pickupEnemiesMax + 1);
        }
    }
}
