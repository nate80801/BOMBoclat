using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoxBehavior : MonoBehaviour
{
    private bool is_exit = false;
    [SerializeField] private int enemy_percentage = Globals.hidden_enemy_percent;
    [SerializeField] private int powerup_percentage = Globals.hidden_powerup_percentage;

    [SerializeField] private GameObject powerup_Prefab;
    [SerializeField] private GameObject exitdoor_Prefab;
    [SerializeField] private GameObject enemy_Prefab  = null;

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private SpriteRenderer m_SpriteRenderer;
    private GameObject hidden_entity = null;

    // Start is called before the first frame update
    void Start()
    {
        Globals.WorldMap.Add(transform.position, gameObject);

        if(is_exit == true) return;
        

        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        if(Random.Range(0,100) < powerup_percentage){
            m_SpriteRenderer.color = Color.green;
            hidden_entity = powerup_Prefab;
        } 
        else if(Random.Range(0,100) < enemy_percentage){
            m_SpriteRenderer.color = Color.red;
            // hidden_entity = Instantiate(object, transform.position, Quaternion.identity).setActive(false);
            
        }
    }

    void OnDestroy(){

        /*
        // plays box breaking audio
        //  FIX: change audio to a longer / more unique one
        audioManager.PlaySFX(audioManager.Box_Breaking);
        */
        
        Globals.WorldMap.Remove(transform.position);

        if(!this.gameObject.scene.isLoaded) return;
        // Instantiate objects here
        if(hidden_entity != null) Instantiate(hidden_entity, transform.position, Quaternion.identity);
        Globals.IncreaseScore(1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Hostile"){
            Debug.Log("Box has entered a trigger");
           //Destroy(gameObject); // DOESNT FUCKING WORK
        }
    }

    public void InitExit(){
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        // if(hidden_entity != null) Destroy(hidden_entity);
        // Instantiate Exit
        hidden_entity = exitdoor_Prefab;
        is_exit = true;
        //m_SpriteRenderer.color = Color.black;

        Debug.Log("Exit at " + Globals.VectorToString(transform.position));
    }

}
