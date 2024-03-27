using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public int range = 1;
    [SerializeField] private float EXPLOSION_DELAY = 2;
    [SerializeField] private GameObject Blast_Prefab;
    [SerializeField] public GameObject Mother_Object; //What gameObject spawned this bomb?
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
        for(int i = 1; i <= range; i++){
            Vector3 newPosition = transform.position + Direction * i;
            Instantiate(Blast_Prefab, newPosition, Quaternion.identity).SetActive(true);
            if(Globals.WorldMap.ContainsKey(newPosition)){
                Destroy(Globals.WorldMap[newPosition]);
                Globals.WorldMap.Remove(newPosition);
                return;
            }
        }
    }

    public IEnumerator Explode(){

        // Delay
        for(int i = 0; i  < EXPLOSION_DELAY; i++){
            // we delay for EXPLOSION_DELAY seconds

            //CHANGE_SPRITE(WHITE)
            //REVERT_SPRITE()
            yield return new WaitForSeconds(EXPLOSION_DELAY);
        }


        Instantiate(Blast_Prefab, transform.position, Quaternion.identity).SetActive(true);
        ExplodeLine(UP);
        ExplodeLine(RIGHT);
        ExplodeLine(LEFT);
        ExplodeLine(DOWN);

        BombSpawner BombSpawner_Component = Mother_Object.GetComponent<BombSpawner>();
        BombSpawner_Component.StoreBomb();
        BombSpawner_Component.SetRemove(transform.position);
        Destroy(gameObject);
    }
}
