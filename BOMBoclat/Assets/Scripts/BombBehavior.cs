using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MonoBehaviour
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
        Globals.WorldMap.Add(transform.position, gameObject);

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
        Globals.WorldMap.Remove(transform.position);

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
                GameObject foundObj = Globals.WorldMap[newPosition];
                switch(foundObj.tag){
                    case "Wall":
                        return;
                    case "Box":
                        blast.SetActive(true);
                        //foundObj.GetComponent<Collider2D>().enabled = false;
                        foundObj.GetComponent<Animator>().SetTrigger("Break");
                        Destroy(foundObj , GlobalAnimTiming.Box_Break);
                        return;
                }
            }
            blast.SetActive(true);
        }
    }


    public IEnumerator Explode(){

        yield return new WaitForSeconds(Globals.explosion_delay_time);


        GetComponent<Collider2D>().enabled = false;
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

    public void ExplodeImmediately(){
        GetComponent<Collider2D>().enabled = false;
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
