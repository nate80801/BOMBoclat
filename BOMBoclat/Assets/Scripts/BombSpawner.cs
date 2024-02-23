using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private float EXPLOSION_DELAY = 2;
    [SerializeField] private int EXPLOSION_RANGE = 1;
    public GameObject bomb_prefab;
    private float spaceAxis;
    // Do we need this or do we just use Stack.Count
    //[SerializeField] private int bombCount = 1;
    private Stack<GameObject> BombStack = new Stack<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StoreBomb();
    }

    // Update is called once per frame
    void Update()
    {
        spaceAxis = Input.GetAxisRaw("Attack");
        if((spaceAxis == 1) && (BombStack.Count > 0)) StartCoroutine(PlaceBomb());

        //Not zero, then we place a bomb
        
    }

    // Place bomb down
    private IEnumerator PlaceBomb() {
        // Remove bomb from inventory, wait for its behavior to finish then add it back
        GameObject poppedBomb = BombStack.Pop();
        poppedBomb.transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
        poppedBomb.SetActive(true);

        // Delay
        yield return new WaitForSeconds(EXPLOSION_DELAY);

        BombExplode explosionComponent = poppedBomb.GetComponent<BombExplode>();
        explosionComponent.range = EXPLOSION_RANGE;
        explosionComponent.Explode();

        // Add bomb back
        StoreBomb();
    }

    // Can call this from powerups
    public void StoreBomb(){
        BombStack.Push(Instantiate(bomb_prefab));
    }


}
