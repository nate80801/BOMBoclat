using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyScript : MonoBehaviour
{
    private GameObject Player; 
    [SerializeField] private GameObject Box; 
    [SerializeField] private float interval = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");

        StartCoroutine(Move());
    }

    IEnumerator Move() {
        while (true) {
            Vector3 start = transform.position;
            Vector3 newPos = NextMove(Player.transform.position, transform.position);
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

    // returns whether the world tile is occupied by a box/wall
    bool IsWalkable(Vector3 pos) {
        return !Globals.WorldMap.ContainsKey(pos);
    }

    // calculates the manhattan distance between two tiles
    float Distance(Vector3 tile1, Vector3 tile2) {
        float xDist = Mathf.Abs(tile1.x - tile2.x); 
        float yDist = Mathf.Abs(tile1.y - tile2.y); 

        return xDist + yDist; 
    }

    // if the ending tile is unobstructed, returns the shortest distance to the tile 
    // if it is obstructed, returns the maximum Integer value
    float DistIfPossible(Vector3 start, Vector3 end) {
        if (IsWalkable(end))
            return Distance(start, end);
        return float.MaxValue;
    }

    // calculates the next tile to move to based on the player's current location 
    Vector3 NextMove(Vector3 playerPos, Vector3 enemyPos) {
        Vector3 newPos;
        Vector3 boxSize = Box.GetComponent<Renderer>().bounds.size;

        // get positions of surroudning tiles 
        Vector3 upTile = new Vector3(enemyPos.x, enemyPos.y + boxSize.y, enemyPos.z);
        Vector3 downTile = new Vector3(enemyPos.x, enemyPos.y - boxSize.y, enemyPos.z);
        Vector3 rightTile = new Vector3(enemyPos.x + boxSize.x, enemyPos.y, enemyPos.z);
        Vector3 leftTile = new Vector3(enemyPos.x - boxSize.x, enemyPos.y, enemyPos.z);

        // calculate the distance to the player for all surrounding tiles 
        float distUp = DistIfPossible(playerPos, upTile);
        float distDown = DistIfPossible(playerPos, downTile); 
        float distRight = DistIfPossible(playerPos, rightTile);
        float distLeft = DistIfPossible(playerPos, leftTile);
        
        // set the next tile to the direction that is closest to the player 
        if (distUp <= distDown && distUp <= distRight && distUp <= distLeft) 
            newPos = upTile;
        else if (distDown <= distUp && distDown <= distRight && distDown <= distLeft)
            newPos = downTile;
        else if (distRight <= distUp && distRight <= distDown && distRight <= distLeft)
            newPos = rightTile;
        else 
            newPos = leftTile;

        // return the next tile 
        return newPos; 
    }

    void OnTriggerEnter2D(Collider2D obj) {
        if (obj.gameObject.tag == "Hostile") {
            GameObject.Destroy(gameObject);
            Debug.Log("hit explosion - destroying enemy");
        }
    }
}
