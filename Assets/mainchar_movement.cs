using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
public class mainchar_movement : MonoBehaviour
{
     public Slider energyBar;
    public float speed = 15f;
    public float jumpVelocity = 15f;
    public float energy = 1000f;
    public bool isZone; // to check the energy deduction
    public Animator animator;
    
    private Rigidbody2D mybody;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask gridLayerMask;

    //private int timeOfJump = 0;
    private float groundY;
    private float jumpY;
    private int jumpCounter = 0;

    private bool allowTrigger1;
    private bool allowTrigger2;
    private bool allowTrigger3;

    public bool doubleJump = false;
    public Transform[]     powerStation;
    public bool[]     powerIsBroken;
    public GameObject  tip1;
    public GameObject  tip2;
    public GameObject  tip3;
    //public GameInputController controller;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("electricity1"))
        {
            tip1.SetActive(true);
            allowTrigger1 = true;
            
        }
        if(collision.CompareTag("electricity2"))
        {
            tip2.SetActive(true);
            allowTrigger2 = true;
        }
        if(collision.CompareTag("electricity3"))
        {
            tip3.SetActive(true);
            allowTrigger3 = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if(collision.CompareTag("electricity1"))
        {
            tip1.SetActive(false);
            allowTrigger1 = false;

        }
         if(collision.CompareTag("electricity2"))
        {
           tip2.SetActive(false);
           allowTrigger2 = false;
           
        }
        if(collision.CompareTag("electricity3"))
        {
            tip3.SetActive(false);
            allowTrigger3 = false;
           
        }
    }

    private void controlElectricity(){

        if (allowTrigger1){
            if(Input.GetKeyDown(KeyCode.E))
            {
                print("发电站1解锁");
                powerIsBroken[0] =true;
                if (energy <= 0){
                    energy = 1000;
                }
            }
        }
        if (allowTrigger2){
            if(Input.GetKeyDown(KeyCode.E))
            {
                print("发电站2解锁");
                powerIsBroken[1] =true;
                if (energy <= 0){
                    energy = 1000;
                }
            }
        }
        if (allowTrigger3){
            if(Input.GetKeyDown(KeyCode.E))
            {
                print("发电站3解锁");
                powerIsBroken[2] =true;
                if (energy <= 0){
                    energy = 1000;
                }
            }
        }
        
    }


    private void Awake()
    {
      
        Debug.Log("started");
        //controller = new GameInputController();
        //controller.player.move_forward.performed += CTX => MoveForward();
        //controller.player.move_backward.performed += CTX => MoveBackward();


        mybody = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }
    public void energyConsume()
    {
            if(!powerIsBroken[0])
            {
                    if(transform.position.x>powerStation[0].position.x&&transform.position.x<powerStation[1].position.x)
                    {
                        if(mybody.velocity.x>0)
                        {
                            if (energy >= 0)
                            {energy-= Time.deltaTime*150f;}
                            
                        }
                    }
            }
            if(!powerIsBroken[1])
            {
                    if(transform.position.x>powerStation[1].position.x&&transform.position.x<powerStation[2].position.x)
                    {
                        if(mybody.velocity.x>0)
                        {
                            if (energy >= 0)
                            {energy-= Time.deltaTime*150f;}
                        }
                    }
            }
            if(!powerIsBroken[2])
            {
                    if(transform.position.x>powerStation[2].position.x)
                    {
                        if(mybody.velocity.x>0)
                        {
                            if (energy >= 0)
                            {energy-= Time.deltaTime*150f;}
                        }
                    }
            }
        
    }
    // Update is called once per frame
    void Update()
    {   
        energyBar.value = energy/1000f;
        energyConsume();
        controlElectricity();
        animator.SetBool("isWalking", false);
        
        HanldJump();
        HandleMovement();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
            animator.SetBool("isLanding", true);
            doubleJump = true;
            jumpCounter = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isLanding",false);
        }
    }

    private void HanldJump(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCounter <= 1)
            {
                if (jumpCounter == 1)
                {
                    animator.SetBool("isDoubleJumping", true);
                }

                mybody.velocity = Vector2.up * jumpVelocity * 1.618f;
                jumpCounter++;
            }
        }
    }

    private void MoveForward()
    {
        
        
        if (energy > 0)
        {
            Debug.Log("MoveForward");
            //animator.Play("WALKING");
            mybody.velocity = new Vector2(speed, mybody.velocity.y);
            animator.SetBool("isWalking", true);

        }
        else{
            Debug.Log("EnergyUsedUp");
        }
  

    }

    private void MoveBackward()
    {
        animator.SetBool("isWalking", true);
        Debug.Log("MoveBackward");
        //animator.Play("WALKING");

        mybody.velocity = new Vector2(-speed, mybody.velocity.y);

    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveBackward();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveForward();
        }
        else
        {
            // No keys pressed
            //animator.Play("IDLE");
            mybody.velocity = new Vector2(0, mybody.velocity.y);
        }

    }
}    

