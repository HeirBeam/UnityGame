using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScore : MonoBehaviour
{
    Text text; 

    void Start()
    
    {
        string levelHighScoreName = SceneManager.GetActiveScene().name + "HighScore";
        //int levelNumber = int.Parse(levelName.Remove(0,5));
        text=GetComponent<Text>();
        Debug.Log ("THE TEXT COMPONENT FOR HIGH SCORE IS " + text);
        if (levelHighScoreName == "Win SceneHighScore") {
            //Debug.Log("---------------------------------------THIS IS WHERE THE HIGH SCOREIS = WIN SCENEHIGHSCORE");
            int _HighScore = PlayerPrefs.GetInt("TotalHighScore");
            text.text = ("HIGH SCORE: " + _HighScore);
        }
        else {
            //Debug.Log("THIS IS WHRE THE HIGH SCORE NAME IS NORMAL ====================================");
            int _HighScore = PlayerPrefs.GetInt(levelHighScoreName);
            //int scoreForLevel = PlayerScores.levelScores[levelNumber -1];
            text.text = ("HIGH SCORE: " + _HighScore);
        }
    }
}
