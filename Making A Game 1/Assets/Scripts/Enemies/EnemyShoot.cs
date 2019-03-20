using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float shotTime;
    public float variance;
    public GameObject shot;

    private Transform shotParent;

    // Start is called before the first frame update
    void Start()
    {
        shotParent = GameObject.Find("Shots").transform;
        StartCoroutine(WaitToShoot());
    }

    IEnumerator WaitToShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shotTime + Random.Range(-variance, variance));
            Instantiate(shot, transform.position, transform.rotation, shotParent);
        }
    }
}
