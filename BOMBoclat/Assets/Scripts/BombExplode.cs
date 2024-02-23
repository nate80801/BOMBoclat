using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplode : MonoBehaviour
{
    public int range = 1;
    public GameObject Blast_Prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if(Globals.boxMap.ContainsKey(newPosition)){
                Destroy(Globals.boxMap[newPosition]);
                Globals.boxMap.Remove(newPosition);
                return;
            }
        }
    }

    public void Explode(){
        Instantiate(Blast_Prefab, transform.position, Quaternion.identity).SetActive(true);
        ExplodeLine(UP);
        ExplodeLine(RIGHT);
        ExplodeLine(LEFT);
        ExplodeLine(DOWN);
        Destroy(gameObject);
    }
}
