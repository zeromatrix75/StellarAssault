using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    //private bool isPaused = false;
    private float savedTimeScale;

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }*/
    }

    public void PauseGame()
    {
        //isPaused = true;
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {
        //isPaused = false;
        Time.timeScale = savedTimeScale;
    }
}
