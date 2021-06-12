using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public float getPickable()
    {
        GameObject[] pickables;
        pickables = GameObject.FindGameObjectsWithTag("Pickable");
        GameObject p = null;
        Vector3 position = transform.position;
        float diff = 0f;
        float distance = 2.5f;
        foreach (GameObject pickable in pickables)
        {
            Vector3 difference = pickable.transform.position - position;
            //Debug.Log("DIFFERENCE:" + difference);

            if (difference.z < distance)
            {
                diff = difference.z;
                p = pickable;
            }

        }
        return diff;

    }
    private void Start()
    {

    }
    private void Update()
    {

        Debug.Log("PICKABLE:" + getPickable());
    }

















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
