/***********************
 * Name: Thomas Allen
 * Date: 1/4/2021
 * Desc: Pauses and unpauses game
 * ********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseFunctions : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pausePanel;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        pausePanel.SetActive(isPaused);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;
        pausePanel.SetActive(isPaused);
    }
}
