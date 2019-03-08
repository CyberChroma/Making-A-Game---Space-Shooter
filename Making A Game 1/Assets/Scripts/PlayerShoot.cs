﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float shotTime;
    public GameObject shot;

    private bool canShoot = true;
    private Transform shotParent;

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
            Instantiate(shot, transform.position, transform.rotation, shotParent);
            StartCoroutine(WaitToShoot());
        }
    }

    IEnumerator WaitToShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(shotTime);
        canShoot = true;
    }
}