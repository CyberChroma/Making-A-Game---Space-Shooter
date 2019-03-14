using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shotTime;
    public GameObject shot;
    public Transform[] shotSpawns;
    public float tripleShotActiveTime;

    private bool canShoot = true;
    private Transform shotParent;
    private bool tripleShot = false;

    // Start is called before the first frame update
    void Start()
    {
        shotParent = GameObject.Find("Shots").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            if (tripleShot)
            {
                Instantiate(shot, shotSpawns[0].position, shotSpawns[0].rotation, shotParent);
                Instantiate(shot, shotSpawns[1].position, shotSpawns[1].rotation, shotParent);
                Instantiate(shot, shotSpawns[2].position, shotSpawns[2].rotation, shotParent);
            }
            else
            {
                Instantiate(shot, shotSpawns[0].position, shotSpawns[0].rotation, shotParent);
            }
            StartCoroutine(WaitToShoot());
        }
    }

    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotTime);
        canShoot = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gun Pickup"))
        {
            StartCoroutine(WaitToDeactivate());
            Destroy(other.gameObject);
        }
    }

    IEnumerator WaitToDeactivate()
    {
        tripleShot = true;
        yield return new WaitForSeconds(tripleShotActiveTime);
        tripleShot = false;
    }
}
