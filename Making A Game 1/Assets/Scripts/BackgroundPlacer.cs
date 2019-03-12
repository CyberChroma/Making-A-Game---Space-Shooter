using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPlacer : MonoBehaviour
{

    public Transform[] objects;
    public float xMin = -100;
    public float xMax = 100;
    public float yMin = -150;
    public float yMax = -100;
    public float zMin = -100;
    public float zMax = 100;
    public bool randDir = false;

    public float speed = 100;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
            if (randDir)
            {
                objects[i].rotation = Random.rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].position = new Vector3(objects[i].position.x, objects[i].position.y, objects[i].position.z - speed * Time.deltaTime);
            if (objects[i].position.z < zMin)
            {
                objects[i].position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), zMax);
            }
        }
    }
}
