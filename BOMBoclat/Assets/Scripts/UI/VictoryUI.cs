using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryUI : MonoBehaviour
{
    public GameObject congrats; 

    public GameObject highScore; 
    public TextMeshProUGUI highScoreText; 

    public GameObject playerScore; 
    public TextMeshProUGUI playerScoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        congrats.SetActive(false);
        StartCoroutine(FlashCongrats());

        highScoreText = highScore.GetComponent<TextMeshProUGUI>();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");

        playerScoreText = playerScore.GetComponent<TextMeshProUGUI>();
        playerScoreText.text = "Your Score: " + Globals.SCORE;
    }

    IEnumerator FlashCongrats() 
    {
        while(true) 
        {
            congrats.SetActive(!congrats.activeInHierarchy);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
