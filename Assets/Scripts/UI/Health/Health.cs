using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]private float startingHealth;
    [SerializeField]public float currentHealth{get; private set;}
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOffFlashes;
    private SpriteRenderer spriteRend;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;


    private void Awake() {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage) {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0 , startingHealth);
        Debug.Log(gameObject.tag);
        if(currentHealth >0) {
            anim.SetTrigger("hurt");
            StartCoroutine(Invulnerability());
        }
        else{
            if(!dead) {
                //Deactivates all attached components
                foreach (Behaviour component in components){
                    component.enabled = false;
                }

                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                
                Debug.Log("The name of the gameobject that has just died is " +gameObject.name );
                if(gameObject.name=="Player 1"){
                    anim.SetBool("grounded", true);
                }
                
                anim.SetTrigger("die");
                
                dead = true;

                if (gameObject.tag == "Enemy"){
                    Debug.Log("ADDING POINTS FOR KILLING ENEMY");
                    int currentScore = PlayerPrefs.GetInt("currentScore");
                    PlayerPrefs.SetInt("currentScore" , currentScore+10);
                    LevelLoader.finalScore +=10;
                    //ScoreScript.scoreValue += 10;
                }

                if (gameObject.tag =="Player")
                {
                    LivesScript.Lives -= 1;
                    LevelLoader.finalScore -= 10; 
                    //ScoreScript.scoreValue -= 10;
                }
                

            }
        }

    }

    public void AddHealth(float _value) {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0 , startingHealth);
    }

    public void Respawn() {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idle");
        StartCoroutine(Invulnerability());
        
        foreach (Behaviour component in components){
            component.enabled = true;
        }
        
    }

    private IEnumerator Invulnerability() {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOffFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOffFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration/(numberOffFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
    private void Deactivate() {
        gameObject.SetActive(false);
    }
 
}
