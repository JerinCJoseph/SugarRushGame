using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMangement : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;

    public void OnGameOver()
    {
        gameOverUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0; //pause
    }

    public void RestartLevel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; //unpause
    }

    public void StartMenuScene()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1; //unpause
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnPauseClicked()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0; //pause
       
    }
    public void OnResumeClicked()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1; //unpause
    }
}
