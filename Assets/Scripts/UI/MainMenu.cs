using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameObject tileBuilding;
    public Button ContinueButton;

    public void NewGame() {
        int TotalHighScore = PlayerPrefs.GetInt("TotalHighScore");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("currLevel", 2);
        PlayerPrefs.SetInt("TotalHighScore", TotalHighScore);
        TimerScript.timeRemaining = TimerScript.startTime;
        SceneManager.LoadScene(1);
    }

    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("currLevel");   
        if (levelAt <= 2 ) 
        {
            ContinueButton.gameObject.SetActive(false);
            ContinueButton.interactable = false;
        }
   }

    public void QuitGame() {
        Debug.Log("Quit");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif
        Application.Quit();
    }
}
