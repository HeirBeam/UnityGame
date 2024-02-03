using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikehead : EnemyDamage
{
    [Header("SpikeHead Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float range;
    [SerializeField] private float checkDelay;
    [SerializeField] private LayerMask playerLayer;
    private Vector3[] directions = new Vector3[4];
    private Vector3 destination;
    private float checkTimer;
    private bool attacking;
    


    private void OnEnable() {
        Stop();
    }


    private void Update() {
        //Move the spikehead to destination only if it is attacking
        if (attacking)
            transform.Translate(destination * Time.deltaTime * speed);
        else {
            checkTimer += Time.deltaTime;
            if(checkTimer > checkDelay)
                CheckForPlayer();
        }
    }
    private void CheckForPlayer() {
        CalculateDirections();
        //Checks if the spikehead can see the player

        for (int i = 0; i < directions.Length; i++)
        {
            Debug.DrawRay(transform.position, directions[i], Color.red);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, playerLayer );

            if(hit.collider != null && !attacking){
                attacking=true;
                destination = directions[i];
                checkTimer = 0; 
            }
        }
    }

    private void CalculateDirections() {
        directions[0] = transform.right * range; //right direction
        directions[1] = -transform.right * range; //left direction
        directions[2] = transform.up * range; //up direction
        directions[3] = -transform.up * range; //down direction
 
    }

    private void Stop() {
        destination = transform.position; //Set destination as current position 
        attacking = false;

    }


}