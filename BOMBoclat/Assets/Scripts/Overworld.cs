using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To use System Random instead of Unity Random
public class Overworld : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject wallPrefab;

    // Dimensions 
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int boxPercentage;
    [SerializeField] private int ExcludeZone;



    // Start is called before the first frame update
    void Start()
    {

        SpawnBorder();

        SpawnBoxes();

        

    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void SpawnBoxes(){
        
        for(int i = 0; i < x; i++){

            for (int j=0; j<y; j++){
                if(Random.Range(0,100) < boxPercentage){
                    // Make sure spawn zone is not populated
                    if(i + j <= ExcludeZone) continue;

                    Instantiate(boxPrefab, new Vector3(i,j), Quaternion.identity);
                }


            }
        }
    }
}
