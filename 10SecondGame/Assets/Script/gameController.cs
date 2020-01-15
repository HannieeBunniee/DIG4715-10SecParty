/*========Hanniee Tran==========*
 * =========DIG4715C============*
 * =======10 Second Game========*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // to use UI text
using System.Threading; //for the countdown timer i guess?

public class gameController : MonoBehaviour
{
    public Text scoreText;
    public Text winText;
    public Text countdownText;
    private float timeLeft = 10.0f;
    private int score;
    private bool timer;
    // Start is called before the first frame update
    void Start()
    {
        countdownText.text = "";
        winText.text = "";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
            winText.text = "You win!\nCreated by Hanniee";
        
    }
}
