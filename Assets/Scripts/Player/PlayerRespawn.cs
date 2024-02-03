using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake() {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();
    }
    public void CheckRespawn(){

        if(LivesScript.Lives <= 0)
        {
            Debug.Log("You ran out of lives");
            uiManager.GameOver();
        }

        if(currentCheckpoint == null ){
            uiManager.Death();
            return;
        }

        playerHealth.Respawn();
        transform.position = currentCheckpoint.position;
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag =="Checkpoint"){
            currentCheckpoint = collision.transform;
            
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");

        }
    }
}
