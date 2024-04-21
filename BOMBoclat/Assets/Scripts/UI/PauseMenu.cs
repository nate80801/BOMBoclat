using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;
    void Start(){
        pauseMenu.SetActive(false);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused) Resume();
            else Pause();
        }
    }

    public void Pause(){
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // testing


        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        
        
    }

    public void Restart()
    {
        Resume();
        Globals.StartGame();
    }


    
    public void MainMenu()
    {
        Resume();
        GameObject levelLoader = GameObject.Find("LevelLoader");
        Debug.Log(levelLoader);
        if(levelLoader != null) levelLoader.GetComponent<LevelLoader>().LoadNextLevel("MainMenu");
        else SceneManager.LoadScene("MainMenu");

    }
}


