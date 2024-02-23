using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed;

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

        transform.position += new Vector3(hor_axis, vert_axis, 0) * speed * Time.deltaTime;
    }
}
