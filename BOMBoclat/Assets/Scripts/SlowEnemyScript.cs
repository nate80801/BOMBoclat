using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject Box;
    [SerializeField] private float interval = 1.75f; 
    private bool horizMovement, negMovement; 
    
    // Start is called before the first frame update
    void Start()
    {
        System.Random rnd = new System.Random(); 

        // determine direction of movement (vertical/horizontal) randomly 
        horizMovement = false; 
        if (rnd.Next(0, 2) == 0) 
            horizMovement = true; 

        StartCoroutine(Move());
    }

    IEnumerator Move() {
        yield return new WaitForSeconds(1);

        while (true) {
            Vector3 start = transform.position;
            Vector3 newPos = NextMove();
            float curTime = 0; 
            
            while (curTime < interval) {
                
                curTime += Time.deltaTime; 
                transform.position = Vector3.Lerp(start, newPos, curTime / interval);

                // Animator control
                Vector3 deltaPos = transform.position - start;
                GetComponent<Animator>().SetFloat("Horizontal", deltaPos.x);
                GetComponent<Animator>().SetFloat("Vertical", deltaPos.y);

                yield return null; 
            }
            // use newPos.x and .y to control animators
            // Should be okay bc we aren't changing in more than one direction


            // ensure we are at the new position 
            transform.position = newPos; 

        }
    }

    // returns whether a tile is occupied by a box/wall 
    bool IsWalkable(Vector3 pos) {
        return !Globals.WorldMap.ContainsKey(pos);
    }

    // calculates what the next tile to move towards is based on current velocity 
    Vector3 calculateNewPos() {
        Vector3 newPos = transform.position;
        Vector3 boxSize = Box.GetComponent<Renderer>().bounds.size;
        
        if (horizMovement)
            newPos.x = (negMovement) ? transform.position.x - boxSize.x : transform.position.x + boxSize.x;
        else 
            newPos.y = (negMovement) ? transform.position.y - boxSize.y : transform.position.y + boxSize.y;

        return newPos;
    }

    // returns the position of the next tile to move towards
    Vector3 NextMove() {
        Vector3 newPos = calculateNewPos(); 

        // turn around if path is blocked
        if (!IsWalkable(newPos)) {
            negMovement = !negMovement; 
            newPos = calculateNewPos(); 
        }

        // if the path is still blocked after turning around
        if (!IsWalkable(newPos))
            return transform.position; 

        return newPos; 
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.gameObject.tag == "Hostile") {
            GameObject.Destroy(gameObject);
        }
    }


    

}