using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class totalScore : MonoBehaviour
{
    public static int scoreForAllLevels;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
    
        text=GetComponent<Text>();
        
        calcTotalScore();

        int TotalHighScore = PlayerPrefs.GetInt("TotalHighScore"); 

            if(scoreForAllLevels > TotalHighScore) {
                //Debug.Log ("_----------------------------------" + scoreForAllLevels + " is more than " +TotalHighScore);
                PlayerPrefs.SetInt("TotalHighScore", scoreForAllLevels);
            }
        text.text = "TOTAL SCORE: " + scoreForAllLevels;
        
    }

    public static void calcTotalScore() {
        PlayerPrefs.SetInt("TotalScore", 0);
        scoreForAllLevels = 0;
        for (int i = 0; i < 7; i++)
        {
            
            int x = i+1;
            string ppLevelName = "Level" + x +  "Score";
            //Debug.Log("-------------------------------THE LEVEL NAME IS "+ ppLevelName + "-------------------------------");
            int levelScore = PlayerPrefs.GetInt(ppLevelName);
            //Debug.Log("-------------------------------THE SCORE FOR LEVEL "+ ppLevelName +" is "+ levelScore+ "-------------------------------");
            scoreForAllLevels = scoreForAllLevels + levelScore;
            PlayerPrefs.SetInt("TotalScore", scoreForAllLevels);
           
        }
         
    }
}
