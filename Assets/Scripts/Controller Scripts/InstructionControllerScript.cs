using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionControllerScript : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("GameplayScene");
    }
}
