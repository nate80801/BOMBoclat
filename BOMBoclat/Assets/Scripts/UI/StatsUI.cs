using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StatsUI : MonoBehaviour
{
    public TextMeshPro Bomb;
    public TextMeshPro Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bomb.text = "" + Globals.current_bomb_count;
        Score.text = "" + Globals.SCORE;
    }
}
