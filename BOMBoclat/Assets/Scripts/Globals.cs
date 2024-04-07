using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public static class Globals
{
    // Constant gameplay quantities
    public static int explosion_delay_time = 2; //Seconds it takes for a bomb to explode
    public static float blast_dissolve_time = .25f; // how long it takes for the smoke to clear from the explosion

    // Map stuff
    public static Dictionary<Vector3, GameObject> WorldMap = new Dictionary<Vector3, GameObject>();
    
    public static int hidden_enemy_percent = 0;
    public static int hidden_powerup_percentage = 5;


    // SCORE STUFF
    public static int SCORE = 0;
    public static void IncreaseScore(int n){
        SCORE += n;
    }


    // PLAYER STATS
    public static int player_lives = 3;
    public static float player_speed = 5f;
    public static int current_bomb_count = 1;
    public static int blast_range = 1;


    public static string VectorToString(Vector3 vector){
        return("x: " + vector.x + ", y: " + vector.y);
    }

    // Adjusters, used to decrement or increment these attributes
    public static void DecrementLives(){
        player_lives--;
    }

    public static void IncrementLives(){
        player_lives++;
    }


    // Resetting, used for respawning
    private static void ResetLives(){
        player_lives = 3;
    }
    private static void ResetSpeed(){
        player_speed = 5;
    }    

    private static void ResetBombCount(){
        current_bomb_count = 1;
    }
    private static void ResetBlastRange(){
        blast_range = 1;
    }

    // Level stuff
    // Levle naming standards: Level 1, Level 2, etc.
    public static int Level;
    public static void StartGame(){ // Call this from main menu or restart button, basically level 1
        // Load in level 1 with initial stats
        HardReset();
        SceneManager.LoadScene("Level 1");
        Level = 1;
    }

    public static void NextLevel(){ // Call from prev level
        Debug.Log("Next Level triggered");
        SoftReset();
        if(Level == 3){
            // TODO: If we are on the final level, load the final level dance party    
            return;
        }
        else{
            SceneManager.LoadScene("Level " + (++Level));
        }
    }
    // Load the next scene

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




