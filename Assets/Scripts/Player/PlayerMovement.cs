using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] float speed;
    [SerializeField] float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    
    [Header ("Pause")]
    [SerializeField] public GameObject pauseScreen;
    
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    public static Rigidbody2D rb;
    
    private void Awake() { 

        //Gets the reference for rigid body and animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (Time.timeScale != 0){
        if (Input.GetKeyDown(KeyCode.Escape)){//Checks whether the pause screen is active and pauses if false or unpauses if true
            //if(pauseScreen.activeInHierarchy)
            //    PauseGame(false);
            //else
                PauseGame(true);
        }   
        horizontalInput = Input.GetAxis("Horizontal");
        //Flips the player left and right depending on where they are moving
        if(horizontalInput>0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f) {
            transform.localScale = new Vector3(-1, 1, 1);

        }

        //Set animator parameters
        anim.SetBool("run", horizontalInput !=0);
        anim.SetBool("grounded", isGrounded());

        //jump 
        if (Input.GetKeyDown(KeyCode.Z))
            Jump();
        
        //Adjustable Jump height
        if(Input.GetKeyUp(KeyCode.Z) && body.velocity.y >0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y/2);

        
        else {
            body.gravityScale = 3;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if(isGrounded()){
                coyoteCounter = coyoteTime;
                jumpCounter = extraJumps;
            }
            else 
                coyoteCounter -= Time.deltaTime;
        }
        }
        
    }

    void Jump(){
        if (coyoteCounter <=0  && jumpCounter <= 0) return;

        
        
            if(isGrounded())
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            
            else 
            {
                if(coyoteCounter> 0)
                {
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                }
                else 
                {
                    if(jumpCounter > 0)
                    {

                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter --;
                        
                    }
                }
            }
            coyoteCounter=0;
        
    
    }


    
    bool isGrounded(){
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

   
    #region Pause

    public void PauseGame(bool status) {
        pauseScreen.SetActive(status);

        //Freezes the game when paused

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    #endregion

    
    

    }

    