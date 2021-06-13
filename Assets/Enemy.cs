using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    bool scared;
    private void Start()
    {
        scared = false;
    }
    private void Update()
    {

    }
    public bool isScared()
    {
        return scared;
    }
    public void setScared(bool s)
    {
        scared = s;
    }


}
