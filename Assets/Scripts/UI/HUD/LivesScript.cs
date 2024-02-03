using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour

{
    public GameObject UI;
    public static int Lives = 3;
    Text livesText;
    // Start is called before the first frame update
    void Start()
    {
        livesText=GetComponent<Text>();
    }

    public void Update() {
        
        if (Lives == 1) {
            livesText.text = Lives.ToString() + " Life";
        }
        else {
            livesText.text = Lives.ToString() + " Lives";
        }
        if (Lives <= 0 )
            {
                Debug.Log("Times up");
                Lives = 0;
                UI = GameObject.Find("UICanvas");
                UI.GetComponent<UIManager>().GameOver();
            }
    }

    public void DecreaseLives() {
        Lives -= 1;
    }

}