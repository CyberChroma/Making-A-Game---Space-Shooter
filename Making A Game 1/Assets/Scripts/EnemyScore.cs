using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    public int score = 10;

    private ScoreUI scoreUI;

    // Start is called before the first frame update
    void Start()
    {
        scoreUI = FindObjectOfType<ScoreUI>();
    }

    public void AddScore ()
    {
        scoreUI.AddScore(score);
    }
}
