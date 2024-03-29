using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Globals.WorldMap.ContainsKey(transform.position)){
            Destroy(gameObject);
            return;
        }
        Globals.WorldMap.Add(transform.position, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
