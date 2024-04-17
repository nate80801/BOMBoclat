using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private PlayerMovement playerMovement;

    AudioManager audioManager;
    Overworld overworldComponent;
    Animator animator;
    Collider2D thisCollider;
    Rigidbody2D thisRigidbody;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        overworldComponent = GameObject.FindGameObjectWithTag("OverworldSpawner").GetComponent<Overworld>(); // Use DelayedRespawnPlayer()
    }

    // Start is called before the first frame update
    void Start()
    {
        thisCollider = GetComponent<Collider2D>();
        thisRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerMovement = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.name + " : " + gameObject.name);
        if(col.gameObject.tag == "Hostile"){
            Die();
        }
        else if(col.gameObject.tag == "PowerUp"){
            PowerUpBehavior PowerComponent = col.gameObject.GetComponent<PowerUpBehavior>();
            PowerComponent.Activate();
            Destroy(col.gameObject);
            
            Globals.IncreaseScore(10);
        }
        else if(col.gameObject.tag == "ExitDoor"){
            audioManager.PlaySFX(audioManager.Exit_Door);
            Globals.IncreaseScore(1000);
            Globals.NextLevel();
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Hostile"){
            Die();
        }
    }



    void OnTriggerExit2D(Collider2D col){ // To fix bomb collisions w player
        if(col.gameObject.tag == "Bomb"){
            col.isTrigger = false;
        }
    }

    private void Die(){ 

        // plays player dying audio
        audioManager.PlaySFX(audioManager.Player_Dying);

        Vanish();
        animator.SetBool("IsDead", true);
        Globals.DecrementLives();
        if(Globals.player_lives == 0){
            Destroy(gameObject);
            Globals.HardReset();
        }
        else{
            StartCoroutine(DelayedRespawn());
        }
        
/*      THIS WORKS BUT IM TESTING SOMETHING ELSE
        // Make it look like the game object is destroyed by vanishing it
        // Make the player reset to spawn then make the object appear again
        Globals.DecrementLives();
        if(Globals.player_lives == 0){
            // Game Over
            Destroy(gameObject);
            Debug.Log("Game Over!");
            Globals.SaveHighScore();
            Globals.HardReset();
        }
        else{
            overworldComponent.DelayedRespawnPlayer(); // vanishes player then unvanishes them
        }
*/
    }


    private IEnumerator DelayedRespawn(){


        yield return new WaitForSeconds(Globals.explosion_delay_time);
        Globals.MediumReset();

        // Re enable the player
        transform.position = new Vector3(0, 0);
        UnVanish();
        animator.SetBool("IsDead" , false);




    }

    private void Vanish(){
        //spriteRenderer.enabled = false;
        thisCollider.enabled = false;

        thisRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
        playerMovement.enabled = false;
    }

    private void UnVanish(){ // I'm too lazy to actually destroy the game object

        //spriteRenderer.enabled = true;
        thisCollider.enabled = true;

        thisRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerMovement.enabled = true;
        
    }

    void Respawn(){
        Globals.MediumReset();
        gameObject.transform.position = new Vector3(0,0);

    }
    
}
