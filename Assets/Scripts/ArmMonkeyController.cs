using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMonkeyController : MonoBehaviour
{
    Rigidbody rb;
    Rigidbody pickableRb;

    public GameObject hands;
    public GameObject angleDetector;
    GameObject[] trees;
    GameObject pickable;

    public float speed = 1f;
    float horizontal;
    public float force = 20f;
    float angle = 45f;

    bool facingRight = true;
    bool canClimb;
    bool holding;
    bool peakedAngle = false;




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //picking
        pickable = null;
        holding = false;
        //for climbing
        canClimb = false;


    }


    private void OnTriggerEnter(Collider other)
    {

        //climb trees
        if(other.tag == "Tree")
        {
            canClimb = true;
        }
        if (other.tag == "Pickable" && !holding)
        {
            pickable = other.gameObject;
            pickableRb = pickable.GetComponent<Rigidbody>();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tree")
        {
            canClimb = false;
        }
        if (other.tag == "Pickable" && !holding)
        {
            pickable = null;
            pickableRb = null;
        }

    }

    private void Update()
    {


        Move();

        if (Input.GetKey(KeyCode.Space))
        {    
                PickUpObject();
                holding = true;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(holding == true)
            {
                ThrowObject();
                holding = false;
            }
        }


        
    }

    //Changes facing direction
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(100f, 180f, 0f);
    }

    private void Move()
    {
        //move
        Vector3 playerMovement = new Vector3(0, 0, Input.GetAxis("Horizontal") * speed);
        transform.position += playerMovement * speed * Time.deltaTime;

        //climb
        if (canClimb)
        {
            rb.velocity = new Vector3(0, Input.GetAxis("Vertical") * speed, 0);
        }

        //flip
        horizontal = playerMovement.z;
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
    }

    //picks object
    private void PickUpObject()
    {
        if (pickable != null)
        {

            pickable.transform.position = hands.transform.position;
            pickableRb.useGravity = false;
            if (peakedAngle && angle > 0)
            {
                angle-=0.3f;
                if (angle <= 0.2)
                {
                    peakedAngle = false;
                }
            }
            else if (peakedAngle == false && angle < 90)
            {
                angle+=0.3f;
                if (angle >= 90)
                {
                    peakedAngle = true;
                }

            }
            if (!facingRight) { angleDetector.transform.eulerAngles = new Vector3(-angle, 0, 0); }
            else
            {
                angleDetector.transform.eulerAngles = new Vector3(angle, 0, 0);
            }
        }
    }

    private void ThrowObject()
    {
        float xcomponent = Mathf.Cos(360 - angle * Mathf.PI / 180)*force;
        float ycomponent = Mathf.Sin(360 - angle * Mathf.PI / 180)*force;
        xcomponent = Mathf.Abs(xcomponent);
        ycomponent = Mathf.Abs(ycomponent);
        if (!facingRight)
        {
            xcomponent = -xcomponent;
        }
        if (pickable != null)
        {
            pickableRb.AddForce(0, ycomponent, xcomponent,ForceMode.Impulse);
            pickableRb.useGravity = true;
            pickable = null;
            pickableRb = null;
        }
    }

}
