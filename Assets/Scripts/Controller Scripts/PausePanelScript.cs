using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanelScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausePanel;

    // Update is called once per frame
    void Update()
    {
    }

    public void Resume(){
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause(){
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

}
