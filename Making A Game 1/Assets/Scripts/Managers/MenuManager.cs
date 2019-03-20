using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private SaveManager saveManager;

    // Start is called before the first frame update
    void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame ()
    {
        saveManager.New();
        SceneManager.LoadScene("Level Select");
    }

    public void ContinueGame ()
    {
        saveManager.Load();
        SceneManager.LoadScene("Level Select");
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
