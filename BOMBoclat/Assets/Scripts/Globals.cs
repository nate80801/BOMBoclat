using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public static class Globals
{
    


    public static Dictionary<Vector3, GameObject> WorldMap = new Dictionary<Vector3, GameObject>();
    
    public static int player_lives = 3;
    public static float player_speed = 5f;
    public static int current_bomb_count = 1;
    public static int blast_range = 1;
    public static int explosion_delay_time = 2; //Seconds it takes for a bomb to explode
    public static float blast_dissolve_time = .25f; // how long it takes for the smoke to clear from the explosion

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




