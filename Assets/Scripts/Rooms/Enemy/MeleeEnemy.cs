using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layers")]
    [SerializeField] private LayerMask playerLayer;
    private float  cooldownTimer = Mathf.Infinity;



    private Animator anim;
    private Health playerHealth;
    Rigidbody2D rb;
    GameObject p1; 
    private EnemyPatrol enemyPatrol;

    private void Awake() {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update(){ 
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight()){
             //Attack only when the player is in sight
             if(cooldownTimer >= attackCooldown){
                cooldownTimer = 0;
                anim.SetTrigger("meleeAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight() {
            RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance, new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0 , Vector2.left, 0 , playerLayer);
            if(hit.collider !=null)
                playerHealth = hit.transform.GetComponent<Health>();
            return hit.collider !=null;
    }

    private void OnDrawGizmos() {
        //Helps to show the range 
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right *range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void DamagePlayer(){
        if(PlayerInSight()){
            playerHealth.TakeDamage(damage);
        }
    }

    private void  OnCollisionEnter2D(Collision2D other) {
        Debug.Log("YOU COLLIDED WITH "+other.collider);
        p1 = GameObject.Find("Player 1");
        if(other.collider.name =="Player 1") {
            Debug.Log("YOU HIT THE PLAYER");
            Vector2 direction = (other.transform.position - transform.position).normalized;
            Vector2 knockback = direction * 10f;
            rb = p1.GetComponent<Rigidbody2D>();
            p1.GetComponent<Rigidbody2D>().AddForce(knockback,ForceMode2D.Impulse);
            rb.AddForce(knockback, ForceMode2D.Force);      
            p1.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
