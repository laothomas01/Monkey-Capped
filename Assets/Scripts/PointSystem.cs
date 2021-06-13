using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public int points = 0;
    void Start()
    {

    }
    public void Update()
    {
        //Debug.Log("POINTS:" + getPoints());

    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), " Score: " + points);
    }

}
