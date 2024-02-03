using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class LevelSelector : MonoBehaviour
{
    
    public void LoadLevel(int level) {
        TimerScript.timeRemaining = TimerScript.startTime;
        SceneManager.LoadScene("Level"+level);
    }

    public void LoadScore(){
        SceneManager.LoadScene("Win Scene");
    }

    public void Back() {
        Debug.Log("Going back to Main Menu");
        SceneManager.LoadScene("_MainMenu");
    }
}
