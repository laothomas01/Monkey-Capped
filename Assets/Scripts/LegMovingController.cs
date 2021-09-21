using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovingController : MonoBehaviour
{
    public float moveSpeed = 10f; // speed of the player
    public float jumpForce = 10f; // jump force
    private bool canJump = false;
    public bool jumped = false;
    public float numberOfJumps = 2;
    public float gravity = -20f;
    private bool facingRight = true; // check where the player is facing
    public float horizontal; // values between -1,0,1
    private Animator animator;
    private float timer = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // increase the gravity
    // Player movement
    // updates the canJump boolean
    void FixedUpdate()
    {
        //moves the player based on direction   
        Vector3 playerMovement = new Vector3(0f, 0f, Input.GetAxis("Horizontal"));
        transform.position += playerMovement * moveSpeed * Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else {
            animator.SetBool("isWalking", false);
        }
        //checks if can jump or not
        if (numberOfJumps < 1)
        {
            canJump = false;
        }

    }
    //flip the player in the opposite direction
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void Update()
    {
        //animator.SetBool("Jumped", jumped);
        horizontal = Input.GetAxis("Horizontal"); //set horizontal value
        //flips the player
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        Physics.gravity = new Vector3(0f, gravity, 0f);
        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
            animator.SetBool("isWalking", false);
        }

        float animationSpeed = Mathf.Abs(horizontal);
        //animator.SetFloat("WalkSpeed", animationSpeed);
    }

    //Player Jumps, velocity is et to zero so second jump has the same height
    void Jump()
    {
        jumped = true;
        //Debug.Log("working");
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode.Impulse);
        rb.velocity = new Vector2(0, 0);
        numberOfJumps--;
        // animator.SetBool("Jumped", false);



    }

    //this method checks if the player is on the ground
    private void OnTriggerStay(Collider other)
    {
        canJump = true;


    }

    //set jumps back to 2 when the player hits the ground
    private void OnTriggerEnter(Collider other)
    {
        jumped = false;
        numberOfJumps = 2;

    }
}
