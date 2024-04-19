/**********************************************

Script controlling all scene changes made from UI.

**********************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{
    public void ToMainMenu() 
    {
        Debug.Log("switching to main menu scene");
        SceneManager.LoadScene("MainMenu");
    }

    public void ToNewGame() 
    {
        Debug.Log("starting new game");
        Globals.StartGame(); 
    }

    public void ToSettings()
    {
        Debug.Log("switching to settings scene");
        SceneManager.LoadScene("SettingsMenu");
    }

    public void toInstructions() 
    {
        Debug.Log("switching to instructions scene");
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        Debug.Log("exiting game");
        Application.Quit();
    }
}
