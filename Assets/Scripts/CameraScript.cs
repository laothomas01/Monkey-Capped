using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public List<Transform> targets;

    public float smoothSpeed = 0.5f;
    public Vector3 offset;
    private Vector3 velocity;
    public float minZoom = 40f;
    public float maxZoom = 10f;
    private Camera cam;
    public float limit = 37f;

    //-------------
    private ArmMonkeyController arm;
    private HeadMonkeyController head;
    private LegMovingController leg;
    private PickUpObject pickup;
    private HeadMonkeyScream hms;
    GameObject leg_monkey, head_monkey, arm_monkey, scream;

    //------------------



    private void Start()
    {

        
        leg_monkey = GameObject.Find("Leg_Monkey");
        head_monkey = GameObject.Find("Head_Monkey");
        arm_monkey = GameObject.Find("Arm_Monkey");
        scream = GameObject.Find("Scream");


        arm = arm_monkey.GetComponent<ArmMonkeyController>();
        head = head_monkey.GetComponent<HeadMonkeyController>();
        leg = leg_monkey.GetComponent<LegMovingController>();
        pickup = arm_monkey.GetComponent<PickUpObject>();
        hms = scream.GetComponent<HeadMonkeyScream>();


        cam = gameObject.GetComponent<Camera>();




        arm.enabled = false;
        head.enabled = false;
        hms.enabled = false;

        leg.enabled = true;
        //pickup.enabled = false;
        targets[0] = leg_monkey.transform;
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            arm.enabled = false;
            head.enabled = false;
            hms.enabled = false;

            leg.enabled = true;
            //pickup.enabled = false;
            targets[0] = leg_monkey.transform;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            arm.enabled = true;
            head.enabled = true;
            hms.enabled = true;
            //arm.enabled = false;
            head.enabled = false;
            //pickup.enabled = false;
            //scream.enabled = false;
            hms.enabled = false;
            leg.enabled = false;
            targets[0] = arm_monkey.transform;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            head.enabled = true;
            hms.enabled = true;
            arm.enabled = false;
            leg.enabled = false;

            targets[0] = head_monkey.transform;


            //hms.enabled = true;
            //leg.enabled = true;


            //head.enabled = true;

            //arm.enabled = false;
            ////head.enabled = false;
            ////pickup.enabled = false;
            //leg.enabled = false;
            ////scream.enabled = false;
        }

    }
    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        Vector3 center = getCenterPoint();
        Vector3 newPos = center + offset;
        // Vector3 finalPos = targets.position + offset;
        //Vector3 smoothPos = Vector3.Lerp(transform.position, finalPos, smoothSpeed * Time.deltaTime);
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothSpeed);

        float zoom = Mathf.Lerp(maxZoom, minZoom, GetDistance() / limit);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoom, Time.deltaTime);


    }
    private float GetDistance()
    {
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    private Vector3 getCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }
        Bounds bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.center;
    }
}