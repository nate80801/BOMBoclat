using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// To use System Random instead of Unity Random
public class Overworld : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;

    // Dimensions 
    [SerializeField] private int x;
    [SerializeField] private int y;
    [SerializeField] private int boxPercentage;
    [SerializeField] private int ExcludeZone;



    // Start is called before the first frame update
    void Start()
    {


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

    // Update is called once per frame
    void Update()
    {
        
    }
}
