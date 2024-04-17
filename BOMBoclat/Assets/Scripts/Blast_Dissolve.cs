using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast_Dissolve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
    }
    void OnEnable(){
        Destroy(gameObject, Globals.blast_dissolve_time);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
