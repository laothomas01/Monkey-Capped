using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMonkeyController : MonoBehaviour
{
    public float speed = 1f;
    //f = m * a
    Rigidbody rb;
    Vector3 playerMovement;
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        playerMovement = new Vector3(0, 0, horizontal * speed);
        rb.AddForce( playerMovement * speed * Time.deltaTime);
    }
}
