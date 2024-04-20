using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{

    public LevelLoader levelLoader;

    public void toMainMenu() 
    {
        Debug.Log("main menu button clicked");
        // SceneManager.LoadScene("MainMenu");
        levelLoader.LoadNextLevel("MainMenu");
    }

    public void toNewGame() 
    {
        Debug.Log("new game button clicked");
        Globals.StartGame();
        
        // levelLoader.LoadNextLevel("Level 1");
    }
}
