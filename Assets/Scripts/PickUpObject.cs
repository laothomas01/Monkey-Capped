using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *USE THIS SCRIPT FOR ANY OBJECTS YOU WANT PICKED UP
 * REQUIREMENTS TO USE THIS SCRIPT:
 *  -EMPTY OBJECT'S TRANSFORM FOR HOLDING AN OBJECT
 *  -PICKED UP OBJECT'S RIGID BODY
 *  -THE PICK UPPER'S TRANSFORM
 */


//this script will be assigned to objects needing pick up
public class PickUpObject : MonoBehaviour
{


    //let's get the player object
    public Transform player;
    //let's get our box's rigidbody
    public Rigidbody boxRigidBody;
    //let's get the position of the handHolding object
    public Transform handHoldPosition;

    //our pick up range
    public float pickUpRange;
    public float angle;
    public float angleThreshold;
    public float force;
    public GameObject AngleDetector;
    public bool holdingObject;
    private bool peakedAngle =false;
    private bool flipped = false;
    private void Start()
    {

        force = 450.0f;
        angle = 45.0f;
        angleThreshold = 0;
    }

    private void Update()
    {



        //distance from player = our player's position - our box's position
        Vector3 distanceToPlayer = player.position - this.transform.position;
        //Debug.Log("DISTANCE TO PLAYER:" + distanceToPlayer);
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKey(KeyCode.Space))
        {
            //angle = Random.Range(90, 45);
            //force = Random.Range(400, 500);
    
            PickUp();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            flipped = true;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            flipped = false;
        }
        if (holdingObject)
        {
            if (peakedAngle && angle >0)
            {
                angle--;
               if(angle == 0)
                {
                    peakedAngle = false;
                }
            }
            else if(peakedAngle == false && angle <90 )
            {
                angle++;
                if (angle == 90)
                {
                    peakedAngle = true;
                }

            }
            if (flipped) { AngleDetector.transform.eulerAngles = new Vector3(-angle, 0, 0); }
            else
            {
                AngleDetector.transform.eulerAngles = new Vector3(angle, 0, 0);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (holdingObject)
            {
                Drop();
            }
        }



    }
    private void PickUp()
    {

        this.transform.position = handHoldPosition.position;
        this.transform.SetParent(player);
        this.boxRigidBody.useGravity = false;
        holdingObject = true;
    }
    //Dropping objects and throwing
    private void Drop()
    {
        holdingObject = false;
        this.transform.parent = null;
        this.boxRigidBody.useGravity = true;

        Throw();


    }
    //when an object is dropped, it's thrown.
    private void Throw()
    {
       
        float xcomponent = Mathf.Cos(360-angle * Mathf.PI / 180) * force;
        float ycomponent = Mathf.Sin(360-angle * Mathf.PI / 180) * force;
        if (flipped)
        {
            xcomponent = -xcomponent;
        }
        boxRigidBody.AddForce(0, ycomponent, xcomponent);
    }














    //public float getPickable()
    //{
    //    GameObject[] pickables;
    //    pickables = GameObject.FindGameObjectsWithTag("Pickable");
    //    GameObject p = null;
    //    Vector3 position = transform.position;
    //    float diff = 0f;
    //    float distance = 2.5f;
    //    foreach (GameObject pickable in pickables)
    //    {
    //        Vector3 difference = pickable.transform.position - position;
    //        //Debug.Log("DIFFERENCE:" + difference);

    //        if (difference.z < distance)
    //        {
    //            diff = difference.z;
    //            p = pickable;
    //        }

    //    }
    //    return diff;

    //}
    //private void Start()
    //{

    //}
    //private void Update()
    //{

    //    Debug.Log("PICKABLE:" + getPickable());
    //}

















    //public GameObject handHeldPosition;
    //public GameObject[] pickable;
    //void Start()
    //{
    //    pickable = GameObject.FindGameObjectsWithTag("Pickable");

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    //private void OnTriggerEnter(Collider other)
    //{

    //    Debug.Log(" SPhere Collided with object");
    //    other.transform.position = handHeldPosition.transform.position;
    //    other.transform.parent = handHeldPosition.transform;

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("Stopped Colliding with object");
    //}



    //-----------------------------------------------------
    /*
     * 
     *
     *
     * onCollision(collide other)
     * {
     *   other.transform.position = handheldposition.transform.positon 
     *  other.transform.parent = handheldposition.transform
     * }
     * 
     * 
     */
    //destination
    //public Transform handHeldPosition;
    //bool dropObject;
    //bool pickupObject;
    //bool collidedWithObject;
    //private void FixedUpdate()
    //{
    //    //    if (collidedWithObject)
    //    //    {
    //    if (Input.GetKey(KeyCode.Space))
    //    {

    //        if (collidedWithObject)
    //        {
    //            //GetComponent<Rigidbody>().freezeRotation = true;
    //            Debug.Log("Picked Up");
    //            GetComponent<Rigidbody>().useGravity = false;
    //            this.transform.position = handHeldPosition.transform.position;
    //            this.transform.parent = GameObject.Find("HandHoldPosition").transform;

    //        }

    //    }

    //    //}
    //    if (Input.GetKeyUp(KeyCode.Space))
    //    {

    //        //GetComponent<Rigidbody>().freezeRotation = false;
    //        Debug.Log("Dropped");
    //        GetComponent<Rigidbody>().useGravity = true;

    //        this.transform.parent = null;
    //        collidedWithObject = false;
    //    }

    //}



    //private void OnTriggerEnter(Collider collision)
    //{

    //    collidedWithObject = true;
    //    Debug.Log("Collided");
    //}

    //private void OnTriggerExit(Collider collision)
    //{
    //    collidedWithObject = false;
    //    Debug.Log("Not Collided");
    //}


    //------------------------------------















    // Start is called before the first frame update

    //private void OnMouseDown()
    //{
    //    GetComponent<Rigidbody>().useGravity = false;
    //    this.transform.position = handHeldPosition.transform.position;
    //    this.transform.parent = GameObject.Find("HandHoldPosition").transform;
    //}
    //private void OnMouseUp()
    //{
    //    this.transform.parent = null;
    //    GetComponent<Rigidbody>().useGravity = true;
    //}
    //void Update()
    //{
    //    //if (Input.GetKey(KeyCode.Space))
    //    //{
    //    //    pickUpButtonPressed = true;

    //    //}
    //    //else
    //    //{
    //    //    pickUpButtonPressed = false;
    //    //}
    //    //if (Input.GetKeyUp(KeyCode.Space))
    //    //{
    //    //    dropObjectButtonPressed = true;
    //    //}
    //    //else
    //    //{
    //    //    dropObjectButtonPressed = false;
    //    //}
    //if (Input.GetKeyDown(KeyCode.Space))
    //{
    //    spacePressed++;
    //    this.transform.position = handHeldPosition.transform.position;
    //    this.transform.parent = GameObject.Find("HandHoldPosition").transform;


    //}
    //    if (spacePressed > 1)
    //    {
    //        this.transform.parent = null;
    //        spacePressed = 0;
    //    }


    //}


    //void FixedUpdate()
    //{
    //    //if (pickUpButtonPressed)
    //    //{

    //    //}
    //    //if (dropObjectButtonPressed)
    //    //{
    //    //    this.transform.parent = null;
    //    //    GetComponent<Rigidbody>().useGravity = true;
    //    //}
    //}




}
