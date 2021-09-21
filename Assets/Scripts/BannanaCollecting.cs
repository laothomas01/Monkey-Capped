using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannanaCollecting : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject collider;
    private GameObject scoreManager;
    void Awake()
    {
        scoreManager = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position,Vector3.up,20*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        collider = other.gameObject;
        if (other.tag == "Monkey")
        {
            if (scoreManager != null)
            {
                scoreManager.GetComponent<LevelUIManager>().score++;
            }
            Destroy(gameObject);
        }

    }
}
