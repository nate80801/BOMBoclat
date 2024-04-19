using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;
    public float transitionTime = 0.5f;

    void Start()
    {
        Globals.levelLoader = gameObject.GetComponent<LevelLoader>();
    }

    void Update()
    {
        /*
        // testing if transition works
        if(Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
        */
    }

    public void LoadNextLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
    
    IEnumerator LoadLevel(string sceneName)
    {
        // plays animation
        transition.SetTrigger("Start");

        // waits a second
        yield return new WaitForSeconds(transitionTime);

        // loads scene
        SceneManager.LoadScene(sceneName);
    }

}
