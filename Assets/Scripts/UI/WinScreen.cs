using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LevelSelect() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #endif

    }
}
