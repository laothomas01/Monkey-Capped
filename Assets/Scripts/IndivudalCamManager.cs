using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndivudalCamManager : MonoBehaviour
{
    private ArmMonkeyController arm;
    private HeadMonkeyController head;
    private LegMovingController leg;
    private PickUpObject pickup;
    private HeadMonkeyScream scream;
    GameObject leg_monkey, head_monkey, arm_monkey;

    // Start is called before the first frame update
    private void Start()
    {
        leg_monkey = GameObject.Find("Leg_Monkey");
        head_monkey = GameObject.Find("Head_Monkey");
        arm_monkey = GameObject.Find("Arm_Monkey");


        arm = arm_monkey.GetComponent<ArmMonkeyController>();
        head = head_monkey.GetComponent<HeadMonkeyController>();
        leg = leg_monkey.GetComponent<LegMovingController>();
        //pickup = arm_monkey.GetComponent<PickUpObject>();
        scream = head_monkey.GetComponent<HeadMonkeyScream>();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            arm.enabled = false;
            head.enabled = false;
            

            

        }
    }

}
