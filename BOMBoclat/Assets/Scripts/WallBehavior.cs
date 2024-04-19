using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{

    [SerializeField] Sprite[] sprites;
    [SerializeField] Color[] colors;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = colors[Globals.Level - 1];
        spriteRenderer.sprite = sprites[Globals.Level - 1];
        if(Globals.WorldMap.ContainsKey(transform.position)){
            Destroy(gameObject);
            return;
        }
        Globals.WorldMap.Add(transform.position, gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
