using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        GoInstructions();
        // Globals.StartGame();
        // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
}
