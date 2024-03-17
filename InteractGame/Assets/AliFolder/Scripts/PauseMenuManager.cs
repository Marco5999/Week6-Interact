using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
   public GameObject pauseMenuUI; // Reference to the pause menu UI panel

    private bool isPaused = false; // Flag to track if the game is paused

    void Update()
    {
        // Check for input to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    void PauseGame()
    {
        // Pause the game
        Time.timeScale = 0f;
        isPaused = true;

        // Show the pause menu
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        // Unpause the game
        Time.timeScale = 1f;
        isPaused = false;

        // Hide the pause menu
        pauseMenuUI.SetActive(false);
    }

    public void ExitGame()
    {
        // Quit the application (you can replace this with any other desired action)
        Application.Quit();
    }
}
