using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls Player Movements
public class PlayerMovement : MonoBehaviour
{
    // Use Globals.player_speed for player speed
    private float hor_axis;
    private float vert_axis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor_axis = Input.GetAxisRaw("Horizontal");
        vert_axis = Input.GetAxisRaw("Vertical");        


        transform.position += new Vector3(hor_axis, vert_axis, 0) * Globals.player_speed * Time.deltaTime;
    }
}
