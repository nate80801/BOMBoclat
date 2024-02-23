using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast_Dissolve : MonoBehaviour
{
    [SerializeField] float dissolve_time = .25f;
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnEnable(){
        Destroy(gameObject, dissolve_time);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
