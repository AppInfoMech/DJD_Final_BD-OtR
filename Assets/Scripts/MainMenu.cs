using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenuPlay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainGame");
    }

    public void MainMenuQuit()
    {
        Application.Quit();
    }
}

