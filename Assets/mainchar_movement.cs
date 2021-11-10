using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.InputSystem;
public class mainchar_movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpVelocity = 13f;
    public float energy = 1000f;
    public bool isZone; // to check the energy deduction
    public Animator animator;

    private Rigidbody2D mybody;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask gridLayerMask;

    //private int timeOfJump = 0;
    private float groundY;
    private float jumpY;
    private bool doubleJump;
    private int jumpCounter = 0;

    //public GameInputController controller;

    // Start is called before the first frame update


    private void Awake()
    {
        Debug.Log("started");
        //controller = new GameInputController();
        //controller.player.move_forward.performed += CTX => MoveForward();
        //controller.player.move_backward.performed += CTX => MoveBackward();

        mybody = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        animator.SetBool("isWalking", false);
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

    private void MoveForward()
    {
        animator.SetBool("isWalking", true);
        Debug.Log("MoveForward");
        if (isZone == false)
        {
            if (energy > 0)
            {
                //animator.Play("WALKING");
                mybody.velocity = new Vector2(5, mybody.velocity.y);
                energy--; // revise it later

            }

        }
        else
        {
            //animator.Play("WALKING");
            mybody.velocity = new Vector2(5, mybody.velocity.y);
        }


    }

    private void MoveBackward()
    {
        animator.SetBool("isWalking", true);
        Debug.Log("MoveBackward");
        //animator.Play("WALKING");

        mybody.velocity = new Vector2(-5, mybody.velocity.y);

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

