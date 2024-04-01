using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        Debug.Log(col.gameObject.name + " : " + gameObject.name);
        if(col.gameObject.tag == "Hostile"){
            Die();
            return;
        }
        if(col.gameObject.tag == "PowerUp"){
            PowerUpBehavior PowerComponent = col.gameObject.GetComponent<PowerUpBehavior>();
            PowerComponent.Activate();
            Destroy(col.gameObject);
        }
    }

    void Die(){

        Globals.DecrementLives();
        if(Globals.player_lives == 0){
            // Game Over
            Debug.Log("Game Over!");
            Globals.HardReset();
        }
        else Respawn();


    }

    void Respawn(){
        
        Globals.MediumReset();
        gameObject.transform.position = new Vector3(0,0); // Reset location

    }
    
}
