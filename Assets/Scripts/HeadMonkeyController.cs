using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMonkeyController : MonoBehaviour
{
    public float speed = 10f;
    //f = m * a
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, 0, Input.GetAxis("Horizontal") * speed);
    }
}
