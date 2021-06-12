using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMonkeyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    //get access to the rigidbody
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(0, 0, Input.GetAxis("Horizontal") * speed);
    }

}
