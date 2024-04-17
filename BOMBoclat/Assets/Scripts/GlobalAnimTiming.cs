using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalAnimTiming
{
    // I just want to use this class to define some animation times
    // format: GlobalAnimtiming.Object_Event
    // Example: GlobalAnimtiming.Box_Break

    // We want to Delay the destruction of an object and let the animation play
    public static float Box_Break = .6f; //We call Destroy(Box, GlobalAnimTiming.Box_Break);
    // Start is called before the first frame update
}
