using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
public class LevelUIManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public int score = 0;
    public int banannas = 12;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString() + " / " + banannas;
    }

}
