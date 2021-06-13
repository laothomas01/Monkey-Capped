using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannanaCollecting : MonoBehaviour
{
    // Start is called before the first frame update
    PointSystem p;
    void Start()
    {
        p = new PointSystem();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject == null)
        {
            p.setPoints(p.getPoints() + 1);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "bannana")
        {
            Destroy(this.gameObject);
        }

    }
}
