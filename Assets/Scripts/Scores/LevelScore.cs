using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScore : MonoBehaviour   
{
    Text score; 
    // Start is called before the first frame update
    void Update()
    {
        string levelName = SceneManager.GetActiveScene().name + "Score";
        //int levelNumber = int.Parse(levelName.Remove(0,5));
        int levelScore = PlayerPrefs.GetInt(levelName);

        score=GetComponent<Text>();
        //int scoreForLevel = PlayerScores.levelScores[levelNumber -1];
        score.text = ("LEVEL SCORE: " + levelScore);
    }
}
