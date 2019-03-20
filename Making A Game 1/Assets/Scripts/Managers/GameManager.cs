using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int requiredScore = 500;
    public float fadeInSmoothing;
    public float fadeOutSmoothing;
    public GameObject levelCompleteScreen;
    public GameObject levelFailedScreen;
    public Text endScoreText;

    [HideInInspector] public bool isFading = true;

    private ScoreUI scoreUI;
    private LevelProgressUI levelProgressUI;
    private int score = 0;
    private PauseManager pauseManager;
    private PlayerMove playerMove;
    private PlayerShoot playerShoot;
    private Image fadeIn;
    private SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        pauseManager = FindObjectOfType<PauseManager>();
        playerMove = FindObjectOfType<PlayerMove>();
        playerShoot = FindObjectOfType<PlayerShoot>();
        scoreUI = FindObjectOfType<ScoreUI>();
        levelProgressUI = FindObjectOfType<LevelProgressUI>();
        levelCompleteScreen.SetActive(false);
        levelFailedScreen.SetActive(false);
        endScoreText.gameObject.SetActive(false);
        fadeIn = GameObject.Find("Fade In").GetComponent<Image>();
        fadeIn.color = new Color(0, 0, 0, 1);
        saveManager = FindObjectOfType<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            fadeIn.color = Color.Lerp(fadeIn.color, new Color(0, 0, 0, 0), fadeInSmoothing * Time.deltaTime);
        } else
        {
            fadeIn.color = Color.Lerp(fadeIn.color, new Color(0, 0, 0, 1), fadeOutSmoothing * Time.deltaTime);
        }
    }

    public void LevelComplete()
    {
        playerMove.enabled = false;
        playerShoot.enabled = false;
        pauseManager.enabled = false;
        score = scoreUI.score;
        endScoreText.text = "Score: " + score + " / " + requiredScore;
        endScoreText.gameObject.SetActive(true);
        scoreUI.gameObject.SetActive(false);
        levelProgressUI.gameObject.SetActive(false);
        if (score >= requiredScore)
        {
            if (saveManager.unlockedLevel < saveManager.level + 1)
            {
                saveManager.unlockedLevel = saveManager.level + 1;
                saveManager.Save();
            }
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
        Destroy(FindObjectOfType<MusicManager>().gameObject);
        SceneManager.LoadScene("Level Select");
    }
}
