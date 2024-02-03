using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject timeOverScreen;
    [SerializeField] private GameObject deathScreen;

    [Header ("Pause")]
    [SerializeField] public GameObject pauseScreen;

    public GameObject Loader;

    private void Awake() {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        deathScreen.SetActive(false);
        Time.timeScale = 1;
    }


    #region Game Over
    public void GameOver() {

        Debug.Log("YOU HAVE RUN OUT OF LIVES");
        gameOverScreen.SetActive(true);
        LivesScript.Lives = 3;
        int levelsUnlocked = PlayerPrefs.GetInt("currLevel");
        if (levelsUnlocked <= 8){
            PlayerPrefs.SetInt("currLevel", 2);
        }

        TimerScript.timeRemaining = TimerScript.startTime;
        //ScoreScript.scoreValue = 0;
        Time.timeScale = 0;

    }
    #endregion

    public void Death() 
    {
        Debug.Log("YOU DIED");
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void TimeOver() 
    {
        timeOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart() {
        
        SceneManager.LoadScene(1);
    }

    public void Retry() {
        LivesScript.Lives = 3;
        TimerScript.timeRemaining = TimerScript.startTime;
        //ScoreScript.scoreValue = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Respawn()
    {
        float TimeLeft = TimerScript.startTime;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        TimerScript.timeRemaining = TimeLeft;
    }

    public void NextLevel() {
        Loader = GameObject.Find("LevelLoader");
        //ScoreScript.scoreValue = 0;
        TimerScript.timeRemaining = TimerScript.startTime;
        Loader.GetComponent<LevelLoader>().LoadLevel();
    }

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
