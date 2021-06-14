using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMonkeyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    //get access to the rigidbody
    Rigidbody rb;
    private bool facingRight = true;
    public float horizontal;
    public float vertical;
    bool canClimb = false;
    GameObject[] trees;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

   


    }

    // Update is called once per frame
    void Update()
    {
        trees = GameObject.FindGameObjectsWithTag("Tree");
        GameObject p = null;
        Vector3 position = transform.position;
        float distance = 3;
        foreach (GameObject tree in trees)
        {
            Vector3 difference = tree.transform.position - position;
            Debug.Log(difference.z);
            if (Mathf.Abs(difference.z) < distance)
            {
                canClimb = true;
            }
            else
            {
                canClimb = false;
            }

        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(100f, 180f, 0f);
    }
    private void FixedUpdate()
    {
        Vector3 playerMovement = new Vector3(0, 0, Input.GetAxis("Horizontal") * speed);
        transform.position += playerMovement * speed * Time.deltaTime;
        if (canClimb)
        {
            rb.velocity = new Vector3(0, Input.GetAxis("Vertical")*speed, Input.GetAxis("Horizontal") * speed);
        }

        horizontal = playerMovement.z;
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
    }

}
