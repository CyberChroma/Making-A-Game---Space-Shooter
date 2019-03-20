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

    private Text scoreText;
    private Slider slider;
    private int max;
    private bool isChanging = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentInChildren<Text>();
        max = FindObjectOfType<GameManager>().requiredScore;
        scoreText.text = "Score: 0 / " + max;
        score = 0;
        slider = GetComponent<Slider>();
        slider.value = 0;
        slider.maxValue = max;
        fill.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isChanging && slider.value != max)
        {
            slider.value = Mathf.Lerp(slider.value, score, smoothing * Time.deltaTime);
            if (Mathf.Abs(slider.value - score) < 1)
            {
                slider.value = score;
                isChanging = false;
                if (slider.value < max / 2)
                {
                    fill.color = Color.Lerp(emptyColor, halfColor, slider.value / (max / 2));
                } else
                {
                    fill.color = Color.Lerp(halfColor, fullColor, (slider.value - max / 2) / (max/2));
                }
            }
        }
    }

    public void AddScore (int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score + " / " + max;
        if (score > 0)
        {
            fill.gameObject.SetActive(true);
        }
        isChanging = true;
    }
}
