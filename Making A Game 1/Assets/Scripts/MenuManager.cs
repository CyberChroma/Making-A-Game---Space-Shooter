﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame ()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void ContinueGame ()
    {
        SceneManager.LoadScene("Level Select");
    }

    public void Quit ()
    {
        Application.Quit();
    }
}
