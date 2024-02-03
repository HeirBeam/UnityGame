
using UnityEngine;

public class BelowLevel : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D player) {
        Debug.Log(player);
        if(player.name == "Spikehead"){
            Debug.Log("Spikehead hit below level");
        }
        else{
            Debug.Log("Player has fallen below the level");
            player.GetComponent<Health>().TakeDamage(100);
            }
    }

}
