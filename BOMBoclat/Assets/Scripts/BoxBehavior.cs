using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoxBehavior : MonoBehaviour
{
    private bool is_exit = false;
    [SerializeField] private int enemy_percentage = 20;
    [SerializeField] private int powerup_percentage = 20;


    private SpriteRenderer m_SpriteRenderer;
    private GameObject hidden_entity = null;

    // Start is called before the first frame update
    void Start()
    {
        
        Globals.WorldMap.Add(transform.position, gameObject);

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        if(Random.Range(0,100) < powerup_percentage){
            m_SpriteRenderer.color = Color.green;
            // hidden_entity = Instantiate(object, transform.position, Quaternion.identity).setActive(false);
        } 
        else if(Random.Range(0,100) < enemy_percentage){
            m_SpriteRenderer.color = Color.red;
            // hidden_entity = Instantiate(object, transform.position, Quaternion.identity).setActive(false);
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitExit(){
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // if(hidden_entity != null) Destroy(hidden_entity);
        // Instantiate Exit
        is_exit = true;
        m_SpriteRenderer.color = Color.black;

        Debug.Log("Exit at " + Globals.VectorToString(transform.position));
    }

}
