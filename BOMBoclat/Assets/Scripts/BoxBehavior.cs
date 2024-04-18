using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoxBehavior : MonoBehaviour
{
    private bool is_exit = false;
    [SerializeField] private int enemy_percentage = 15;
    [SerializeField] private int powerup_percentage = 30;

    [SerializeField] private GameObject powerup_Prefab;
    [SerializeField] private GameObject exitdoor_Prefab;

    // Enemy prefabs
    [SerializeField] private GameObject slowEnemyPrefab;
    [SerializeField] private GameObject medEnemyPrefab;
    [SerializeField] private GameObject fastEnemyPrefab;


    [Header("-----------Colors-----------")]
    [SerializeField] Color[] NormalBoxColors;
    [SerializeField] Color[] EvilBoxColors;




    private SpriteRenderer m_SpriteRenderer;
    private GameObject hidden_entity = null;

    

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Globals.WorldMap.Add(transform.position, gameObject);

        if(Globals.Level == 3){
            animator.SetBool("FinalLevel", true);
        } 

        m_SpriteRenderer.color =  NormalBoxColors[Globals.Level - 1];

        if(is_exit == true) return;

        

        if(Random.Range(0,100) < powerup_percentage){
            hidden_entity = powerup_Prefab;
        } 
        else if(Random.Range(0,100) < enemy_percentage){
            animator.SetBool("EnemyHidden", true);
            m_SpriteRenderer.color = EvilBoxColors[Globals.Level - 1];
            

            int rand = Random.Range(0,100);
            // Roll for enemy type
            if(rand < Globals.slowPercentage) hidden_entity = slowEnemyPrefab;
            else if(rand < Globals.medPercentage + Globals.slowPercentage) hidden_entity = medEnemyPrefab;
            else if(rand < Globals.fastPercentage + Globals.slowPercentage + Globals.medPercentage) hidden_entity = fastEnemyPrefab;
            
        }
    }


    // Need Overworld game object just for this uffghh
    private GameObject overworldSpawnerObject;
    void OnDestroy(){
        if(!this.gameObject.scene.isLoaded) return;

        overworldSpawnerObject = GameObject.FindGameObjectWithTag("OverworldSpawner");
        Overworld overworldComponent = overworldSpawnerObject.GetComponent<Overworld>();
        
        Globals.WorldMap.Remove(transform.position);
        Debug.Log(hidden_entity);

        // Instantiate objects here
        if(hidden_entity != null) overworldComponent.DelayedInstantiate(hidden_entity, transform.position,  Globals.blast_dissolve_time);
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
