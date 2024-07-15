using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameMenu : MonoBehaviour
{
    public GameObject pauseGameMenu;

    /*void Start()
    {
        Cursor.visible = true; // Hide the cursor initially
        Cursor.lockState = CursorLockMode.None; // Lock the cursor initially
    }*/

    public void OnPauseClicked()
    {
        Time.timeScale = 0; // Pause the game
        pauseGameMenu.SetActive(true); // Show the pause menu
       // Cursor.visible = true; // Show the cursor
        //Cursor.lockState = CursorLockMode.None; // Unlock the cursor
    }

    public void OnResumeClicked()
    {
        Time.timeScale = 1; // Resume the game
        pauseGameMenu.SetActive(false); // Hide the pause menu
       // Cursor.visible = true; // Hide the cursor
        //Cursor.lockState = CursorLockMode.None; // Lock the cursor
    }

    public void OnRestartClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the level
        //Time.timeScale = 1; // Reset the time scale
    }

    public void OnHomeClicked()
    {
        SceneManager.LoadScene("StartMenu"); // Load the start menu
       // Time.timeScale = 1; // Reset the time scale
    }
}
