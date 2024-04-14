using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    [SerializeField] private GameObject Blast_Prefab;
    [SerializeField] public GameObject Mother_Object; //What gameObject spawned this bomb? Most likely player 

    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Explode());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnEnable(){
        //StartCoroutine(Explode());
    }

    void OnDestroy(){
    }

    private Vector3 UP = new Vector3(0,1);
    private Vector3 RIGHT = new Vector3(1,0);
    private Vector3 DOWN = new Vector3(0,-1);
    private Vector3 LEFT = new Vector3(-1,0);
    private void ExplodeLine(Vector3 Direction){

        for(int i = 1; i <= Globals.blast_range; i++){
            Vector3 newPosition = transform.position + (Direction * i);
            GameObject blast = Instantiate(Blast_Prefab, newPosition, Quaternion.identity);

           // blast.transform.SetParent(gameObject); // Set the parent of it so that all of the blast will execute ontriggerenter2d

            
            
            if(Globals.WorldMap.ContainsKey(newPosition)){
                switch(Globals.WorldMap[newPosition].tag){
                    case "Wall":
                        return;
                    case "Box":
                        blast.SetActive(true);
                        Destroy(Globals.WorldMap[newPosition]);
                        return;                    
                }
            }
            blast.SetActive(true);
        }
    }


    public IEnumerator Explode(){

        // Delay
        for(int i = 0; i  < Globals.explosion_delay_time; i++){
            // we delay for Globals.explosion_delay_time seconds

            //CHANGE_SPRITE(WHITE)
            //REVERT_SPRITE()
            yield return new WaitForSeconds(Globals.explosion_delay_time);
        }


        Instantiate(Blast_Prefab, transform.position, Quaternion.identity).SetActive(true);

        ExplodeLine(UP);
        ExplodeLine(RIGHT);
        ExplodeLine(LEFT);
        ExplodeLine(DOWN);

        // plays bomb explosion audio
        audioManager.PlaySFX(audioManager.Bomb_Explosion);


        BombSpawner BombSpawner_Component = Mother_Object.GetComponent<BombSpawner>();
        BombSpawner_Component.StoreBomb();
        BombSpawner_Component.SetRemove(transform.position);

        Destroy(gameObject);
    }
}
