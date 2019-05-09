using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public int rotation = 0;
    public float disToNext = 20;
    public float xMin = 2;
    public float xMax = 4;
    public float yMin = 4;
    public float yMax = 6;
    public int numEnemy1 = 10;
    public int numEnemy2 = 5;
    public int numEnemy3 = 10;
    public int numEnemy4 = 3;
}

public class LevelCreator : MonoBehaviour
{
    public Wave[] waves;

    public Transform enemies;
    public Transform turnPoints;
    
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject turnPoint;
    public GameObject levelEnd;

    private int[] enemiesLeft = new int[4];
    private int enemyTypesLeft = 0;
    private float xRadius = 10;
    private float spawnPosX = 0;
    private float spawnPosZ = 15;
    private float zRowPos = 15;

    private int whileCounter = 0;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            Instantiate(turnPoint, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.Euler (new Vector3(0, 180, 0)), turnPoints).GetComponent<TurnTrigger>().yRot = waves[i].rotation * 45;
            if (waves[i].rotation == 0 || waves[i].rotation == 4 || waves[i].rotation == 8)
            {
                xRadius = 8;
            }
            else if (waves[i].rotation == 1 || waves[i].rotation == 3 || waves[i].rotation == 5 || waves[i].rotation == 7)
            {
                xRadius = 6;
            }
            else
            {
                xRadius = 4;
            }
            spawnPosX = -xRadius;
            enemiesLeft[0] = waves[i].numEnemy1;
            enemiesLeft[1] = waves[i].numEnemy2;
            enemiesLeft[2] = waves[i].numEnemy3;
            enemiesLeft[3] = waves[i].numEnemy4;
            zRowPos = spawnPosZ;
            whileCounter = 0;
            while ((enemiesLeft[0] + enemiesLeft[1] + enemiesLeft[2] + enemiesLeft[3]) != 0 && whileCounter <= 100000)
            {
                spawnPosX += Random.Range(waves[i].xMin, waves[i].xMax);
                if (spawnPosX > xRadius)
                {
                    spawnPosX = -xRadius;
                    zRowPos += 2 * waves[i].yMin;
                }
                spawnPosZ = zRowPos + (Random.Range(waves[i].yMin, waves[i].yMax) * (Random.Range(0, 2)*2-1));
                if (Physics.OverlapBox(new Vector3(spawnPosX, 0, spawnPosZ), new Vector3(2, 5, 2), Quaternion.identity).Length == 0)
                {
                    enemyTypesLeft = 0;
                    for (int j = 0; j < 4; j++)
                    {
                        if (enemiesLeft[j] != 0)
                        {
                            enemyTypesLeft++;
                        }
                    }
                    int randomEnemy = Random.Range(0, enemyTypesLeft);
                    int enemyToSpawn = -1;
                    for (int j = 0; j < 4; j++)
                    {
                        if (enemiesLeft[j] != 0)
                        {
                            enemyToSpawn++;
                            if (enemyToSpawn == randomEnemy)
                            {
                                enemyToSpawn = j;
                                break;
                            }
                        }
                    }
                    if (enemyToSpawn == 0)
                    {
                        Instantiate(enemy1, new Vector3(spawnPosX, -1, spawnPosZ), Quaternion.Euler(new Vector3(0, 180, 0)), enemies);
                    }
                    else if (enemyToSpawn == 1)
                    {
                        Instantiate(enemy2, new Vector3(spawnPosX, 1, spawnPosZ), Quaternion.Euler(new Vector3(0, 180, 0)), enemies);
                    }
                    else if (enemyToSpawn == 2)
                    {
                        Instantiate(enemy3, new Vector3(spawnPosX, -1, spawnPosZ), Quaternion.Euler(new Vector3(0, 180, 0)), enemies);
                    }
                    else if (enemyToSpawn == 3)
                    {
                        Instantiate(enemy4, new Vector3(spawnPosX, 1, spawnPosZ), Quaternion.Euler(new Vector3(0, 180, 0)), enemies);
                    }
                    enemiesLeft[enemyToSpawn]--;
                }
                whileCounter++;
            }
            if (whileCounter > 99999)
            {
                print("While Loop Infinite!");
                break;
            }
            spawnPosX = 0;
            spawnPosZ += waves[i].disToNext;
        }
        Instantiate(levelEnd, new Vector3(spawnPosX, 0, spawnPosZ), Quaternion.Euler(new Vector3(0, 180, 0)));
    }
}
