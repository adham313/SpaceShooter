using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; 
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ESC Was Pressed!");

            if (isPaused)
            {
                Resume(); 
            }
            else
            {
                Pause(); 
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;          
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);  
        Time.timeScale = 0f;          
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}