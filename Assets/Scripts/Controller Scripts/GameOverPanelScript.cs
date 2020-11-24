using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelScript : MonoBehaviour
{
    public GameObject gameOverPanel;
    
    public void continueGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameplayScene");
    }

    public void LoadMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
