using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [HideInInspector] public int score;

    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: 0";
        score = 0;
    }

    public void AddScore (int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
