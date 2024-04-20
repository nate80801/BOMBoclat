using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Globals
{

    public static AudioClip Level_1;
    public static AudioClip Level_2;
    public static AudioClip Level_3;
    public static AudioClip Victory;
    // public static AudioClip Game_Over;

    public static LevelLoader levelLoader;
    public static AudioManager audioManager;

    public static void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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
        Debug.Log("new score: " + SCORE);
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
    
    public static void LoadScene(string sceneName){
        // Stop SFX
        AudioSource SFX = AudioManagerObject.transform.Find("SFX").gameObject.GetComponent<AudioSource>();
        SFX.Stop();
        SceneManager.LoadScene(sceneName);
        // SFX.Play();
    }

    
    
    public static int Level = 1;
    public static void StartGame(){ // Call this from main menu or restart button, basically level 1
        Level = 1;
        
        // fades to level 1 scene
        levelLoader.LoadNextLevel("Level 1");

        // plays level 1 audio
        if(Level_1 != null && Level == 1)
        {
            audioManager.ChangeBGM(Level_1);
        }
        
        // Load in level 0 with initial stats
        HardReset();
        // SceneManager.LoadScene("Level 0");
        // Level = 1;
    }

    public static void NextLevel(){ // Call from prev level

        Debug.Log("Next Level triggered");
        SoftReset();

        Level += 1;

        if(Level == 4){
            Debug.Log("You win!!!!");  
            SaveHighScore();
            // SceneManager.LoadScene("Victory Screen");

            // NEED TO FIX
            // fades to victory scene
            levelLoader.LoadNextLevel("Victory Screen"); 

            // plays victory audio
            if(Victory != null)
            {
                audioManager.ChangeBGM(Victory);
            }

            return;
        }
        else{
            // Advance to next level
            // TODO: Increase difficulty by increasing enemy count, hidden enemy probability, etc.
            // Level += 1;

            if(Level_2 != null && Level == 2 )
            {
                // plays level 2 audio
                audioManager.ChangeBGM(Level_2);
            }

            else if(Level_3 != null && Level == 3)
            {
                // plays level 3 audio
                audioManager.ChangeBGM(Level_3);
            }
            
            //LoadScene("Level " + (Level));

            // SceneManager.LoadScene("Level " + (Level));
            if(Level < 4)
            {
                levelLoader.LoadNextLevel("Level " + (Level));
            }
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

    // Used to save the player's high score after the game ends
    public static void SaveHighScore() 
    {
        if (SCORE > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", SCORE);
 
            // TODO: flash "new high score!" on screen? 
           
            Debug.Log("new high score set: " + PlayerPrefs.GetInt("highScore"));
        } 
    }










    




}




