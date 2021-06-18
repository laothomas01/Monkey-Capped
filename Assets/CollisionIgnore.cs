using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    private GameObject[] monkeys;
    // Start is called before the first frame update
    void Start()
    {
        monkeys = GameObject.FindGameObjectsWithTag("Monkey");

        //Ignore collisions will other monkeys
      
    }
    private void Update()
    {
        for (int i = 0; i < monkeys.Length; i++)
        {
            Physics.IgnoreCollision(monkeys[i].GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
