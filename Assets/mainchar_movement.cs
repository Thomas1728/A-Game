using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
//using UnityEngine.InputSystem;
public class mainchar_movement : MonoBehaviour
{
    public float speed = 10f;
    public float jumpVelocity = 250f;
    public float energy = 1000f;
    public bool isZone ;     // to check the energy deduction

    private Rigidbody2D mybody;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask gridLayerMask;

    //private int timeOfJump = 0;
    private float groundY;
    private float jumpY;
    private bool doubleJump;

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
        if (IsGrounded() ){
            doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            if (IsGrounded()){
                Debug.Log("Jump");
                mybody.velocity = Vector2.up * jumpVelocity * 1.618f;
            } else {
                if (doubleJump){
                    Debug.Log("DoubleJump");
                    mybody.velocity = Vector2.up * jumpVelocity;
                    doubleJump = false;
                }
            }
            
        }

        HandleMovement();
    }

    private bool IsGrounded() {
        RaycastHit2D rch2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, gridLayerMask);
        Debug.Log(rch2D.collider);
        return rch2D.collider != null;
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

    private void HandleMovement() {
        if (Input.GetKey(KeyCode.A)){
            MoveBackward();
        } else {
            if (Input.GetKey(KeyCode.D)){
                MoveForward();
            } else {
                // No keys pressed
                mybody.velocity = new Vector2(0, mybody.velocity.y);
            }
        }
    }
}
