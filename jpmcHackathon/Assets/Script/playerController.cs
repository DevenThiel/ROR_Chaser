using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public Transform groundCheck; //transform: any object placed in world so it has a lcoation and stuff
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public float jumpSpeed;
    public Rigidbody2D myRigidbody;
    public LevelManager theLevelManager;

    public float moveSpeed;
    private float activeMoveSpeed;


    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        theLevelManager = FindObjectOfType<LevelManager>();
        activeMoveSpeed = moveSpeed;


    }

    // Update is called once per frame
    void Update () {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Input.GetAxisRaw("Horizontal") > 0f)

        { //right is positive and left is negative
            myRigidbody.velocity = new Vector3(activeMoveSpeed, myRigidbody.velocity.y, 0f); //moves object to right but keeps the y component constant with object
            transform.localScale = new Vector3(1f, 1f, 1f); //this makes the player face the right direction when moving right
        }

        else if (Input.GetAxisRaw("Horizontal") < 0f)
        { //right is positive and left is negative
            myRigidbody.velocity = new Vector3(-activeMoveSpeed, myRigidbody.velocity.y, 0f); //moves object to left but keeps the y component constant with object
                                                                                              // negative movespeed to go backwards
            transform.localScale = new Vector3(-1f, 1f, 1f); //this makes the player face the left direction when moving to the left
        }
        else
        {// no input is applied so make him immediately stop that way he doesn't slide around
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f); //moves object to right but keeps the y component constant with object


        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);        }

    }
}
