using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("attack perimeters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] public Transform attackPoint;

    [Header("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("player layer")]
    [SerializeField] private LayerMask enemyLayers;
    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;


    private void Awake() { 
        anim = GetComponent<Animator>();
    }

    private void Update() {

        if(Input.GetKey(KeyCode.X) && cooldownTimer > attackCooldown)
            
            anim.SetTrigger("attack");
        
        cooldownTimer += Time.deltaTime;

    }

    private void Attack() {
        Debug.Log("playing attack trigger");
        anim.ResetTrigger("attack"); 
        cooldownTimer=1;
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayers);
        Debug.Log(hitEnemies);
        //HIT COLLIDER DETECTING NOTHING WHEN MISSING

        foreach(Collider2D x in hitEnemies){
            Debug.Log("The hit collider is" + x);
            Debug.Log("THE NAME OF THE COLLIDER IS " + x);
            if(x.name =="MeleeEnemy"){
                Debug.Log("YOU HIT A MELEE ENEMY");
                x.GetComponent<Health>().TakeDamage(damage);
            }


            else {
                Debug.Log("YOU DIDNT HIT ANYTHING");
                return;
            }
            

        }
        
    }


    private void OnDrawGizmosSelected() {

        if(attackPoint == null)
            return;
        //Helps to show the range 
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, range);
    }


   
}
