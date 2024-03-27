using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static Dictionary<Vector3, GameObject> WorldMap = new Dictionary<Vector3, GameObject>();


    public static string VectorToString(Vector3 vector){
        return("x: " + vector.x + ", y: " + vector.y);
    }
}




