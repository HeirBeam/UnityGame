using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        score=GetComponent<Text>();

        PlayerPrefs.SetInt("currentScore", 0);

        
    }
    // Update is called once per frame
    void Update()
    {
        int levelScore = PlayerPrefs.GetInt("currentScore");

        score=GetComponent<Text>();
        score.text = ("LEVEL SCORE: " + levelScore);
    
    }
}
