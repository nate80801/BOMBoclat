using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private int EXPLOSION_RANGE = 1;
    [SerializeField] private int BOMB_COUNT_START = 1;
    
    [SerializeField] private KeyCode ATTACK_KEY = KeyCode.Space;

    private int BOMB_COUNT_CUR;
    public GameObject bomb_prefab;

    // Map showing where all the bombs are to make sure we don't place bombs in the same location.
    public HashSet<Vector3> BombSet = new HashSet<Vector3>(); // Doesn't need to be global, will not need to access much any where else

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0 ; i < BOMB_COUNT_START; i++){
            StoreBomb();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if((Input.GetKeyDown(ATTACK_KEY)) && (BOMB_COUNT_CUR > 0)) {
            PlaceBomb(); 
            Debug.Log(BOMB_COUNT_CUR);

        }

    }

    // Place bomb down
    private void PlaceBomb() {

        Vector3 Bomb_Location = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y));
        if(BombSet.Contains(Bomb_Location)) return; //do nothing

        // Add bomb location to hashset, reduce current bomb count
        BombSet.Add(Bomb_Location);
        BOMB_COUNT_CUR--;

        // Place the actual bomb
        GameObject Placed_Bomb = Instantiate(bomb_prefab, Bomb_Location, Quaternion.identity);
        




        // Change the range of the bomb
        BombExplode explosionComponent = Placed_Bomb.GetComponent<BombExplode>();
        explosionComponent.Mother_Object = gameObject;
        explosionComponent.range = EXPLOSION_RANGE;

        Placed_Bomb.SetActive(true);

        /*
        // Delay
        yield return new WaitForSeconds(EXPLOSION_DELAY);

        explosionComponent.Explode();

        // Add bomb back
        StoreBomb();
        */
    }

    // Can call this from powerups
    public void StoreBomb(){
        BOMB_COUNT_CUR++;
    }
    public void SetRemove(Vector3 pos){
        BombSet.Remove(pos);
    }


    


}
