using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To use System Random instead of Unity Random
public class Overworld : MonoBehaviour
{

    private GameObject playerObject;
    // Prefabs for GameObjects we referennce
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject wallPrefab;
    // Enemy Prefabs
    [SerializeField] private GameObject enemySlowPrefab;
    [SerializeField] private GameObject enemyMediumPrefab;
    [SerializeField] private GameObject enemyFastPrefab;
    




    // Dimensions of the map, x * y grid
    [SerializeField] private int x;
    [SerializeField] private int y;

    // Spawnzone
    [SerializeField] private int ExcludeZone; // Zone for spawn zone, no other entities will be spawned except for the player

    // % of a game object in the world

    // Make sure all percentages add up to less than 100, try to keep it under 50-60ish or else there's like no space at all





    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
        SpawnBorder();
        SpawnWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy(){ // When new scene is loaded, we clear out the hashmap so the next scene will start with an empty hashmap
        Globals.WorldMap.Clear();
    }

    private void SpawnPlayer(){
        playerObject = Instantiate(playerPrefab, new Vector3(0,0), Quaternion.identity);
    }

    private void SpawnBorder(){
        if(x == y){
            for(int i = -1 ; i <= x; i++){
                Instantiate(wallPrefab, new Vector3(-1, i), Quaternion.identity);
                Instantiate(wallPrefab, new Vector3(x, i), Quaternion.identity);

                Instantiate(wallPrefab, new Vector3(i, -1), Quaternion.identity);
                Instantiate(wallPrefab, new Vector3(i, y), Quaternion.identity);

            }
            return;
        }
        for(int i = -1; i <= x; i++){
            //Spawn the horizontal walls
            Instantiate(wallPrefab, new Vector3(i, -1), Quaternion.identity);
            Instantiate(wallPrefab, new Vector3(i, y), Quaternion.identity);

        }
        for(int i = -1; i <=y; i++){
            // Spawn the vertical walls
            Instantiate(wallPrefab, new Vector3(-1, i), Quaternion.identity);
            Instantiate(wallPrefab, new Vector3(x, i), Quaternion.identity);
        }
    }



    private void SpawnWorld(){ // Spawns everything inside of the border
        // Initialize end zone somewhere in the top right of the map
        Vector3 exit = new Vector3(Random.Range(x/2, x), Random.Range(y/2,y));
        GameObject exit_box = Instantiate(boxPrefab, exit, Quaternion.identity);

        BoxBehavior box_behavior_component = exit_box.GetComponent<BoxBehavior>();
        box_behavior_component.InitExit();

        for(int i = 0; i < x; i++){
            for (int j=0; j<y; j++){
                // Make sure spawn zone is not populated
                if(i + j <= ExcludeZone) continue;

                Vector3 cur_location = new Vector3(i,j);
                if(cur_location == exit) continue;


                // The randonm space has a chance to spawn in a box, a wall, or an enemy
                if(Random.Range(0,100) < Globals.boxPercentage){
                    Instantiate(boxPrefab, new Vector3(i,j), Quaternion.identity);
                    continue;
                }

                else if(Random.Range(0,100) < Globals.wallPercentage){
                    if(i % 2 == 1 && j % 2 == 1) Instantiate(wallPrefab, new Vector3(i,j), Quaternion.identity);
                    continue;
                }

                if(Random.Range(0,100) < Globals.enemyPercentage){
                    int rand = Random.Range(0,100);
                    // Roll for enemy type
                    if(rand < Globals.slowPercentage) Instantiate(enemySlowPrefab, new Vector3(i,j), Quaternion.identity);
                    else if(rand < Globals.medPercentage + Globals.slowPercentage) Instantiate(enemyMediumPrefab, new Vector3(i,j), Quaternion.identity);
                    else if(rand < Globals.fastPercentage + Globals.slowPercentage + Globals.medPercentage) Instantiate(enemyFastPrefab, new Vector3(i,j), Quaternion.identity);

                }
            }
            
        }
    }



    // spawning in enemies bc boxes will be disabled before they can start coroutines ughghgh
    // call from boxbehavior.cs
    // stupid stupid stupid 
    public void DelayedInstantiate(GameObject obj, Vector3 pos, float delay){
        StartCoroutine(DelayedInstantiateCoroutine(obj, pos, delay));  
    }
    private IEnumerator DelayedInstantiateCoroutine(GameObject obj, Vector3 pos, float delay){ // to be used
        // To solve bug, make it so that the delay is greater than the blast_dissolve time
        yield return new WaitForSeconds(delay);
        Instantiate(obj, pos, Quaternion.identity);
    }



    
}
