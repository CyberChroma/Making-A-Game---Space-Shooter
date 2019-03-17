using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevel (int level)
    {
        Destroy(FindObjectOfType<MusicManager>().gameObject);
        SceneManager.LoadScene("Level " + level);
    }

    public void Back ()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
