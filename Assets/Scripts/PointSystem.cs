using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : MonoBehaviour
{
    // Start is called before the first frame update
    int points;
    void Start()
    {
        points = 0;
    }
    public void Update()
    {
        Debug.Log("POINTS:" + getPoints());
    }
    public int getPoints()
    {
        return points;
    }
    public void setPoints(int p)
    {
        points = p;
    }

}
