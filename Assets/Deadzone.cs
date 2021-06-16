using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monkey" || other.gameObject.name == "Head_Monkey")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
