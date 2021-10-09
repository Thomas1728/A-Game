using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.InputSystem;
public class mainchar_movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpVelocity = 10f;
    public float energy = 1000f;
    public bool isZone = false;     // to check the energy deduction

    private Rigidbody2D mybody;

    private int timeOfJump = 0;
    private float groundY;
    private float jumpY;

    //public GameInputController controller;

    // Start is called before the first frame update


    private void Awake()
    {
        //controller = new GameInputController();
        //controller.player.move_forward.performed += CTX => MoveForward();
        //controller.player.move_backward.performed += CTX => MoveBackward();



    }
    void Start()
    {
        Debug.Log("started");
        //controller = new GameInputController();
        //controller.player.move_forward.performed += CTX => MoveForward();
        //controller.player.move_backward.performed += CTX => MoveBackward();

        mybody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Jump();

        }


    }


    private void MoveForward() {

        Debug.Log("MoveForward");
        if (isZone == false)
        {
            if (energy > 0)
            {
                mybody.velocity = new Vector2(5, mybody.velocity.y);
                energy--; // revise it later
            }
               
        }
        else
        {
            mybody.velocity = new Vector2(5, mybody.velocity.y);
        }


    }

    private void MoveBackward() {

        Debug.Log("MoveBackward");

        mybody.velocity = new Vector2(-5, mybody.velocity.y);

    }

    private void Jump()
    {
        Debug.Log("Jump");
        while (timeOfJump < 2)
        {
            mybody.velocity = Vector2.up * jumpVelocity;
            timeOfJump++;
        }
        // check the landed condition here
    }
    
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveForward();
            timeOfJump = 0; // remove it
        }
        else if (Input.GetKey(KeyCode.A)) {

            MoveBackward();
            timeOfJump = 0; // remove it

        }

    }
}
