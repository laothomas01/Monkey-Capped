using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannanaCollecting : MonoBehaviour
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
        if (other.tag == "bannana")
        {
            other.GetComponent<PointSystem>().points++;
            Destroy(other);
        }

    }
}
