using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public static class Globals
{
    // Constant gameplay quantities
    public static int explosion_delay_time = 3; //Seconds it takes for a bomb to explode
    public static float blast_dissolve_time = .25f; // how long it takes for the smoke to clear from the explosion

    // Map stuff
    public static Dictionary<Vector3, GameObject> WorldMap = new Dictionary<Vector3, GameObject>();
    
    public static int boxPercentage = 20; // Percent of boxes in the map
    public static int wallPercentage = 20; //Percentage of walls in the map

    public static int enemyPercentage = 5; 
    // Enemy percentages, make sure they add to 100
    public static int slowPercentage = 45;

    public static int medPercentage = 35;
    public static int fastPercentage = 20;

    public static void ResetDifficulty(){
        boxPercentage = 20;
        wallPercentage = 20;
        enemyPercentage = 10; 

        slowPercentage = 45;
        medPercentage = 35;
        fastPercentage = 20;
    }

    public static void IncreaseDifficulty(){
        boxPercentage += 15;
        wallPercentage += 20;
        enemyPercentage += 15;

        slowPercentage -= 15;
        medPercentage += 10;
        fastPercentage += 5;
    }
    


    // SCORE STUFF
    public static int SCORE = 0;
    public static void IncreaseScore(int n){
        SCORE += n;
    }


    // PLAYER STATS
    public static int player_lives = 3;
    public static float player_speed = 3f;
    public static int current_bomb_count = 1;
    public static int blast_range = 1;

    // Default player stats
    private static int DEFAULT_LIVES = player_lives;
    private static float DEFAULT_SPEED = player_speed;
    private static int DEFAULT_COUNT = current_bomb_count;
    private static int DEFAULT_RANGE = blast_range;


    public static string VectorToString(Vector3 vector){
        return("x: " + vector.x + ", y: " + vector.y);
    }

    // Adjusters, used to decrement or increment these attributes
    public static void DecrementLives(){
        player_lives--;
        Debug.Log("Lives: " + player_lives);

    }

    public static void IncrementLives(){
        player_lives++;
    }

    // REMEMBER TO LOOK AT THESE FOR DEFAULT VALUES
    // Resetting, used for respawning
    private static void ResetLives(){
        player_lives = DEFAULT_LIVES;
    }
    private static void ResetSpeed(){
        player_speed = DEFAULT_SPEED;
    }    
    private static void ResetBombCount(){
        current_bomb_count = DEFAULT_COUNT;
    }
    private static void ResetBlastRange(){
        blast_range = DEFAULT_RANGE;
    }

    // Score

    // Level stuff
    // Levle naming standards: Level 1, Level 2, etc.
    public static GameObject AudioManagerObject; // AudioManager.cs sets itself here in Start()
    public static AudioManager audioManagerComponent;
    public static void LoadScene(string sceneName){
        // Stop SFX
        audioManagerComponent = AudioManagerObject.GetComponent<AudioManager>();
        AudioSource SFX = AudioManagerObject.transform.Find("SFX").gameObject.GetComponent<AudioSource>();
        // SFX.Stop();
        audioManagerComponent.enabled = false;
        SceneManager.LoadScene(sceneName);
        audioManagerComponent.enabled = true;
        // SFX.Play();
    }

    
    
    public static int Level = 0;
    public static void StartGame(){ // Call this from main menu or restart button, basically level 1
        // Load in level 0 with initial stats
        HardReset();
        ResetDifficulty();
        LoadScene("Level 1");
        audioManagerComponent.PlayMusic(audioManagerComponent.Gameplay);
        Level = 1;
    }

    public static void NextLevel(){ // Call from prev level

        Debug.Log("Next Level triggered");
        SoftReset();
        if(Level == 3){
            Debug.Log("You win!!!!");
            // TODO: If we are on the final level, load the final level dance party    
            return;
        }
        else{
            // Advance to next level
            // TODO: Increase difficulty by increasing enemy count, hidden enemy probability, etc.
            Level += 1;
            LoadScene("Level " + (Level));
            IncreaseDifficulty();
        }
    }

    public static void LoseGame(){}

    // Used for when we clear a level, moving on to the next map
    public static void SoftReset(){
        ResetSpeed();
    }

    // Used for when we die, but not when we game over, don't reset lives
    public static void MediumReset(){
        ResetSpeed();
        ResetBombCount();
        ResetBlastRange();
    }


    public static void HardReset(){
        MediumReset();
        ResetLives();
    }










    




}




