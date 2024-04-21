using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public GameObject playerScore;
    public TextMeshProUGUI playerScoreText;

    public GameObject highScore; 
    public TextMeshProUGUI highScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        playerScoreText = playerScore.GetComponent<TextMeshProUGUI>();
        playerScoreText.text = "Your Score: " + Globals.SCORE;

        highScoreText = highScore.GetComponent<TextMeshProUGUI>();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        Globals.SCORE = 0;

    }
}
