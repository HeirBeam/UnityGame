using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject player;
    public Slider slider;
    public int nextSceneLoad;
    public Text percentage;
    public GameObject timer;
    public static int finalScore;
    
    [SerializeField] private Behaviour[] components;

    public GameObject completeLevelScreen;
    
    void Start() {
        finalScore = 0;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex +1;
    }

    void OnTriggerEnter2D(Collider2D player) {

            foreach (Behaviour component in components){
                component.enabled = false;
            }
            
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            int TimeLeft = (int)TimerScript.timeRemaining;
        

            finalScore += TimeLeft + 1;
            
            TimerScript.toggleTimer();
            

             
            Debug.Log("The score for this level = " + finalScore);
            string ppLevelName = SceneManager.GetActiveScene().name + "Score";
            string highScoreName = SceneManager.GetActiveScene().name + "HighScore";

            PlayerPrefs.SetInt(ppLevelName,finalScore);
            int levelScore = PlayerPrefs.GetInt(ppLevelName);
            int HighScore = PlayerPrefs.GetInt(highScoreName); 

            if(levelScore > HighScore) {
                Debug.Log ("_----------------------------------" + levelScore + " is more than " + HighScore);
                PlayerPrefs.SetInt(highScoreName, levelScore);
            }

            totalScore.calcTotalScore();

            Debug.Log("The player prefs for this level are " + levelScore + "--------------------------------------------------");


            levelComplete(nextSceneLoad);
             
        
    }



    public void levelComplete(int nextSceneLoad) {
        
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex +1;
        if(nextSceneLoad > PlayerPrefs.GetInt("currLevel")){
            PlayerPrefs.SetInt("currLevel", nextSceneLoad);
        }
        Time.timeScale = 0;

        completeLevelScreen.SetActive(true);
    }

    public void LoadLevel(){
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex +1;
        if(nextSceneLoad > PlayerPrefs.GetInt("currLevel")){
            PlayerPrefs.SetInt("currLevel", nextSceneLoad);
        }
        StartCoroutine(LoadAsynchronously(nextSceneLoad));  
    }

    IEnumerator LoadAsynchronously (int nextSceneLoad){

        AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneLoad);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            percentage.text = progress * 100f +"%";
            yield return null;
        }
    
    }

}
