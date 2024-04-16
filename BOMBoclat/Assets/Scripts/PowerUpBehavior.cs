using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
  private delegate void Powerup();
  private int roll;
  Powerup[] PowerArr;
  //public AnimatedSpriteRenderer[] powerSprites;

  [Header("Sprites")]  // Use the Header attribute here
  public AnimatedSpriteRenderer increaseSpeed;
  public AnimatedSpriteRenderer bombRadiusBoost;
  public AnimatedSpriteRenderer increaseBombs;

 
  
  AudioManager audioManager;

  private void Awake()
  {
    audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
  }

  // Start is called before the first frame update
  void Start()
  {
    PowerArr = new Powerup[]{
      // List all possible things we want powerups to do
      () => {if(Globals.player_speed < 10) Globals.player_speed += .3f; Debug.Log("new player speed: " + Globals.player_speed);},
      () => {Globals.blast_range++; Debug.Log("new blast range: " + Globals.blast_range);},
      () => {Globals.current_bomb_count++; Debug.Log("new bomb count: " + Globals.current_bomb_count);}
    };

    // Roll for random powerup
    roll = Random.Range(0, PowerArr.Length);  
    if (roll == 0)
        {
            SetSprite(increaseSpeed);
        }
    else if (roll == 1)
        {
            SetSprite(bombRadiusBoost);
        }
    else if (roll == 2)
        {
            SetSprite(increaseBombs);
        }
  }

   private void SetSprite(AnimatedSpriteRenderer spriteRenderer)
    {
        // Set the sprite renderer to active
        increaseSpeed.enabled = false;
        bombRadiusBoost.enabled = false;
        increaseBombs.enabled = false;

        // Set the current sprite renderer
        spriteRenderer.enabled = true;
    }
  string[] SpriteArr = new string[]{
    "speedBoost",
    "blastBoost",
    "increaseBombs"
  };

  public void Activate(){
    PowerArr[roll]();

    // plays power up audio
    audioManager.PlaySFX(audioManager.Powerup);
  }

  // Update is called once per frame
  void Update()
  {
    
  }
}
