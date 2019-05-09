using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public float smoothing;
    public Image fill;
    public Color fullColor = Color.green;
    public Color halfColor = Color.yellow;
    public Color emptyColor = Color.red;

    [HideInInspector] public int score;
    [HideInInspector] public int requiredScore = 0;

    private Text scoreText;
    private Slider slider;
    private bool isChanging = false;

    // Start is called before the first frame update
    void Start()
    {
        EnemyScore[] enemyScores = FindObjectsOfType<EnemyScore>();
        for (int i = 0; i < enemyScores.Length; i++)
        {
            requiredScore += enemyScores[i].score;
        }
        requiredScore = Mathf.FloorToInt(requiredScore * 7/12 / 10) * 10;
        scoreText = GetComponentInChildren<Text>();
        scoreText.text = "Score: 0 / " + requiredScore;
        score = 0;
        slider = GetComponent<Slider>();
        slider.value = 0;
        slider.maxValue = requiredScore;
        fill.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isChanging && slider.value != requiredScore)
        {
            slider.value = Mathf.Lerp(slider.value, score, smoothing * Time.deltaTime);
            if (Mathf.Abs(slider.value - score) < 1)
            {
                slider.value = score;
                isChanging = false;
                if (slider.value < requiredScore / 2)
                {
                    fill.color = Color.Lerp(emptyColor, halfColor, slider.value / (requiredScore / 2));
                } else
                {
                    fill.color = Color.Lerp(halfColor, fullColor, (slider.value - requiredScore / 2) / (requiredScore / 2));
                }
            }
        }
    }

    public void AddScore (int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score + " / " + requiredScore;
        if (score > 0)
        {
            fill.gameObject.SetActive(true);
        }
        isChanging = true;
    }
}
