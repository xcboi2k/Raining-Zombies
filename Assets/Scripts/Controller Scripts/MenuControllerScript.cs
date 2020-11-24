using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour
{
    public GameObject infoPanel;

    public void PlayGame(){
        SceneManager.LoadScene("InstructionScene");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void OpenInfo(){
        infoPanel.SetActive(true);
    }

    public void CloseInfo(){
        infoPanel.SetActive(false);
    }
}
