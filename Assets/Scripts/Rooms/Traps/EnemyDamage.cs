using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] protected float damage;
    Rigidbody2D rb;

    protected void OnTriggerEnter2D(Collider2D collision) {
        Collider2D collider = collision;
        Debug.Log("you have just collided with "+collision.tag);
        if(collision.tag== "Player"){ 
            collision.GetComponent<Health>().TakeDamage(damage);
        }        
    }
}
