using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls Player Movements
public class PlayerMovement : MonoBehaviour
{
    // Use Globals.player_speed for player speed
    private float hor_axis;
    private float vert_axis;

    private Vector3 movement;


    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _LastHorizontal = "LastHorizontal";
    private const string _LastVertical = "LastVertical";
    private const string _Speed = "Speed";

    Rigidbody2D rb;
    Animator animator;

    private float og_speed = Globals.player_speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        hor_axis = Input.GetAxisRaw("Horizontal");
        vert_axis = Input.GetAxisRaw("Vertical");

        movement.Set(hor_axis, vert_axis, 0);
        rb.velocity = movement * Globals.player_speed;      // testing to see if this fixes collisions   


        animator.SetFloat(_Speed , Globals.player_speed - og_speed + 1);
        animator.SetFloat(_horizontal, movement.x);
        animator.SetFloat(_vertical, movement.y);

        if(movement != new Vector3(0,0,0)){
            animator.SetFloat(_LastHorizontal, movement.x);
            animator.SetFloat(_LastVertical, movement.y);

        }


        //transform.position += new Vector3(hor_axis, vert_axis, 0) * Globals.player_speed * Time.deltaTime;
    }
}
