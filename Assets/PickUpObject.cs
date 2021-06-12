using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    //destination
    public Transform handHeldPosition;
    bool dropObject;
    bool pickupObject;
    bool collidedWithObject;
    private void Update()
    {
        if (collidedWithObject)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                this.transform.position = handHeldPosition.transform.position;
                this.transform.parent = GameObject.Find("HandHoldPosition").transform;

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {

                this.transform.parent = null;
                collidedWithObject = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        collidedWithObject = true;
        Debug.Log("Collided");
    }

    private void OnCollisionExit(Collision collision)
    {
        collidedWithObject = false;
        Debug.Log("Not Collided");
    }
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
