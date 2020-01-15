/*========Hanniee Tran==========*
 * =========DIG4715C============*
 * =======10 Second Game========*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//allow UI Text
using System.Threading; //for the countdown timer i guess?


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text scoreText;
    public Text winText;
    public Text countdownText;


    private Rigidbody2D rb2d;
    private float timeLeft = 10.0f;
    private int score;
    private bool timer;
    private bool gameOver;

    public AudioSource musicSource;
    public AudioClip musicClipWin;
    public AudioClip musicClipLose;
    public AudioClip musicBackground;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        score = 0;
        winText.text = "";
        countdownText.text = "";
        musicSource.clip = musicBackground;
        musicSource.Play();
        timer = true;
        //gameOver = false;
        SetScoreText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void Update()
    {
        if (timer == true) //countdown time code
        {
            timeLeft -= Time.deltaTime;
            countdownText.text = (timeLeft).ToString("Time Left: 0");
            if (score == 5)
            {
                timer = false;
            }
            else if (timeLeft < 0 && score <5)
            {
                timer = false;
                Destroy(GameObject.FindWithTag("Bunny"));
                musicSource.Stop();
                musicSource.loop = true;
                musicSource.clip = musicClipLose;
                musicSource.Play();
                winText.text = "Game Over :P!";
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag ("Carrot"))
        {
            score = score + 1; //plus 1 score if pick up a carrot
            other.gameObject.SetActive(false); //disable visual of the carrot
            SetScoreText();
        }
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //jump
            }
        }
    }


    //===Function===
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 5)
        {
            winText.text = "You win! Made by Hanniee Tran.";
            musicSource.Stop();
            musicSource.loop = true;
            musicSource.clip = musicClipWin;
            musicSource.Play();
        }
    }

   
}
