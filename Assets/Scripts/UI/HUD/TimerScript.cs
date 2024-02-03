using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static float startTime = 102;
    public static float timeRemaining = startTime;
    public GameObject UI;
    Text timer;
    public static bool timerIsRunning = false;
    public static int seconds ;

    void Start()
    {
        //TimerScript.timeRemaining  = TimerScript.startTime;
        timerIsRunning = true;
        timer = GetComponent<Text>();
        timer.text = timeRemaining.ToString();
    }

    public static void toggleTimer() {
        timerIsRunning = false;
    }

    void tellTime(float timeToTell) {
        timeToTell += 1;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        seconds = Mathf.FloorToInt(timeToTell %60);
        //float milliSeconds = (timeToTell % 1) * 1000;
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update()
    {
        if (timerIsRunning){
            if (timeRemaining > 0 )
            {
                timeRemaining -= Time.deltaTime;
                tellTime(timeRemaining);
                
            }
        
            else
            {
                if (LivesScript.Lives >= 2 ){
                    Debug.Log("Times up");
                    timeRemaining = 0;
                    timerIsRunning = false;
                    UI.GetComponent<UIManager>().TimeOver();
                    LivesScript.Lives -= 1;
                }
                else {
                    Debug.Log("Lives finished");
                    UI.GetComponent<UIManager>().GameOver();
                }
            }
        }
    }

   
}
