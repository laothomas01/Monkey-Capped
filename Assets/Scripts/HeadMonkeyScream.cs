using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMonkeyScream : MonoBehaviour
{
    // Start is called before the first frame update

    public SphereCollider sc;
    Enemy e;
    void Start()
    {
        sc = GetComponent<SphereCollider>();
        e = new Enemy();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            sc.radius = Random.Range(1f, 3f);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //affect the enemy
        if (other.tag == "enemy")
        {
            e.setScared(true);
            Debug.Log("SCARED:" + e.isScared());
            //when enemy is scared, do an enemy behavior.
        }

    }
    private void OnTriggerExit(Collider other)
    {
        //affect the enemy

    }


}
