using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelUIManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public int score = 0;
    public int banannas = 12;
    public GameObject PauseMenu;
    public static bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString() + " / " + banannas;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseClicked();
        }
    }

    public void pauseClicked()
    {
        
        if (!paused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        
    }
    public void Resume()
    {
        
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
