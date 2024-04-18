using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButtons : MonoBehaviour
{
    public void toMainMenu() 
    {
        Debug.Log("main menu button clicked");
        SceneManager.LoadScene("MainMenu");
    }

    public void toNewGame() 
    {
        Debug.Log("new game button clicked");
        SceneManager.LoadScene("Level 1");
    }
}
