using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.boxMap.Add(transform.position, gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
