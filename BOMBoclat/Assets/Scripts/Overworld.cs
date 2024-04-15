using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To use System Random instead of Unity Random
public class Overworld : MonoBehaviour
{
    // Prefabs for GameObjects we referennce
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject wallPrefab;


    // Dimensions of the map, x * y grid
    [SerializeField] private int x;
    [SerializeField] private int y;

    // Spawnzone
    [SerializeField] private int ExcludeZone; // Zone for spawn zone, no other entities will be spawned except for the player


    [SerializeField] private int boxPercentage = 33; // Percent of boxes in the map
    [SerializeField] private int wallPercentage = 100; //Percentage of walls in the map

    



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
        Instantiate(playerPrefab, new Vector3(0,0), Quaternion.identity);
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
                if(Random.Range(0,100) < boxPercentage){

                    Instantiate(boxPrefab, new Vector3(i,j), Quaternion.identity);
                    continue;
                }

                if(Random.Range(0,100) < wallPercentage){
                    if(i % 2 == 1 && j % 2 == 1) Instantiate(wallPrefab, new Vector3(i,j), Quaternion.identity);
                }
            }
            
        }
    }
}
