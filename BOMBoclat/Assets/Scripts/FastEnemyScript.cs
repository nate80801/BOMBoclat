using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemyScript : MonoBehaviour
{
    private bool horizMovement, negMovement; 
    [SerializeField] private float interval = 0.75f; 
    [SerializeField] private GameObject Box;


    // Start is called before the first frame update
    void Start()
    {
        negMovement = false; 

        // determine direction of movement (vertical/horizontal) randomly 
        System.Random rnd = new System.Random(); 
        horizMovement = false;
        if (rnd.Next(0, 2) == 0)
            horizMovement = true;

        // start the enemy's movement
        StartCoroutine(Move());
    }

    // enemy movement 
    IEnumerator Move() {
        while (true) {
            Vector3 start = transform.position;
            Vector3 newPos = NextMove();
            float curTime = 0; 
            
            while (curTime < interval) {
                curTime += Time.deltaTime; 
                transform.position = Vector3.Lerp(start, newPos, curTime / interval);
                yield return null; 
            }

            // ensure we are at the new position 
            transform.position = newPos; 
        }
    }

    // returns whether a tile is occupied 
    bool IsWalkable(Vector3 pos) {
        return !Globals.WorldMap.ContainsKey(pos);
    }

    // calculate the next tile to move to based on the direction of the current velocity 
    Vector3 CalculateNewPos() {
        Vector3 newPos = transform.position;
        Vector3 boxSize = Box.GetComponent<Renderer>().bounds.size;
        
        if (horizMovement)
            newPos.x = (negMovement) ? transform.position.x - boxSize.x : transform.position.x + boxSize.x;
        else 
            newPos.y = (negMovement) ? transform.position.y - boxSize.y : transform.position.y + boxSize.y;

        return newPos;
    }

    // calculate the next move by checking tiles in all directions 
    Vector3 NextMove() {
        Vector3 newPos = CalculateNewPos();
        // Debug.Log("newPos: " + newPos);

        // change movement direction (horiz/vertical)
        if (!IsWalkable(newPos)) {
            horizMovement = !horizMovement; 
            newPos = CalculateNewPos();
            Debug.Log("not walkable1. new pos: " + newPos); 
       }

        // change movement direction (positive/negative)
       if (!IsWalkable(newPos)) {
            negMovement = !negMovement; 
            newPos = CalculateNewPos();
            Debug.Log("not walkable2. new pos: " + newPos); 
       }

        // change direction to the opposite of the original direction 
        if (!IsWalkable(newPos)) {
            horizMovement = !horizMovement; 
            newPos = CalculateNewPos();
            Debug.Log("not walkable3. new pos: " + newPos); 
       }

        // all directions are obstructed 
       if (!IsWalkable(newPos))
            return transform.position;
        
        return newPos; 
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.gameObject.tag == "Hostile") {
            GameObject.Destroy(gameObject);
            Debug.Log("hit explosion - destroying enemy");
        }
    }
}