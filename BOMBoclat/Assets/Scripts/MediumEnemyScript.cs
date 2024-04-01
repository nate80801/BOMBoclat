using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyScript : MonoBehaviour
{
    public Vector2 speed; 
    public Transform player; 
    // Start is called before the first frame update
    
    void Start()
    {
        speed = new Vector2(0.75f, 0);
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {
            Vector2 directionToMove = (player.position - transform.position).normalized; 
            transform.Translate((directionToMove * speed) * Time.deltaTime);
        }

        transform.Translate(new Vector2(speed.x * Time.deltaTime, speed.y * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Explosion") {
            Destroy(gameObject); 
            Debug.Log("hit explosion - destroying enemy");
        }
    }

    
}
