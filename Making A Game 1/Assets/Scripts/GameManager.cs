using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int requiredScore = 500;
    public GameObject levelCompleteScreen;
    public GameObject levelFailedScreen;
    public Text endScoreText;

    private ScoreUI scoreUI;
    private int score = 0;
    private PauseManager pauseManager;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;

    // Start is called before the first frame update
    void Start()
    {
        pauseManager = FindObjectOfType<PauseManager>();
        playerMove = FindObjectOfType<PlayerMove>();
        playerShoot = FindObjectOfType<PlayerShoot>();
        scoreUI = FindObjectOfType<ScoreUI>();
        levelCompleteScreen.SetActive(false);
        levelFailedScreen.SetActive(false);
        endScoreText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelComplete ()
    {
        playerMove.enabled = false;
        playerShoot.enabled = false;
        pauseManager.enabled = false;
        score = scoreUI.score;
        endScoreText.text = "Score: " + score + " / " + requiredScore;
        endScoreText.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        if (score >= requiredScore)
        {
            levelCompleteScreen.SetActive(true);

        } else
        {
            levelFailedScreen.SetActive(true);
        }
    }

    public void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSelect ()
    {
        SceneManager.LoadScene("Level Select");
    }
}
