using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public Button[] levelButtons;

    private SaveManager saveManager;
    private int unlockedLevel;

    // Start is called before the first frame update
    void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
        unlockedLevel = saveManager.unlockedLevel;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i >= unlockedLevel)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel (int level)
    {
        Destroy(FindObjectOfType<MusicManager>().gameObject);
        saveManager.level = level;
        SceneManager.LoadScene("Level " + level);
    }

    public void Back ()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
