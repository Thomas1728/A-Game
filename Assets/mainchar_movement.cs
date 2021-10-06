using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
public class mainchar_movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpVelocity = 10f;

    public float energy = 1000f;


    private Rigidbody2D mybody;

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

            mybody.velocity = Vector2.up * jumpVelocity;

        }


    }


    private void MoveForward() {

        Debug.Log("moveForward");
        mybody.velocity = new Vector2(5, mybody.velocity.y);

    }

    private void MoveBackward() {

        Debug.Log("MoveBackward");

        mybody.velocity = new Vector2(-5, mybody.velocity.y);

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveForward();
        }
        else if (Input.GetKey(KeyCode.A)) {

            MoveBackward();
        
        }

    }
}
