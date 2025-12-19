using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MultipyScore : MonoBehaviour
{
    [SerializeField] private int multiplier;
    [SerializeField] private TMP_Text scoreText;
    private int score = 0;
    
    private bool multiplyBy2 = false;
    private bool multiplyBy3 = false;
    private bool multiplyBy5 = false;
    private float multiplierTimex2 = 6;
    private float multiplierTimex3 = 6;
    private float multiplierTimex5 = 6;
    [SerializeField] private GameObject multiplyx2;
    [SerializeField] private GameObject multiplyx3;
    [SerializeField] private GameObject multiplyx5;
    private SpriteRenderer spritex2;
    private SpriteRenderer spritex3;
    private SpriteRenderer spritex5;
    
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject exitButton;
    
    [SerializeField] private AudioClip scoreSound;


    private void Awake()
    { 
        spritex2 = multiplyx2.transform.Find("TurnOn").GetComponent<SpriteRenderer>();
        spritex3 = multiplyx3.transform.Find("TurnOn").GetComponent<SpriteRenderer>();
        spritex5 = multiplyx5.transform.Find("TurnOn").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (multiplyx2)
        {
            multiplierTimex2 -= Time.deltaTime;
            if (multiplierTimex2 <= 0)
            {
                multiplyBy2 = false;
                spritex2.enabled  = false;
            }
        }
        else if (multiplyx3)
        {
            multiplierTimex3 -= Time.deltaTime;
            if (multiplierTimex3 <= 0)
            {
                multiplyBy3 = false;
                spritex3.enabled  = false;
            }
        }
        else if (multiplyx5)
        {
            multiplierTimex5 -= Time.deltaTime;
            if (multiplierTimex5 <= 0)
            {
                multiplyBy5 = false;
                spritex5.enabled  = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EndGame"))
        {
            retryButton.SetActive(true);
            exitButton.SetActive(true);
            
            if (score >= GameManager.instance.HighScore)
            {
                GameManager.instance.SetHighScore(score);
            }
        }
        if (other.gameObject.CompareTag("Multiplierx2"))
        { 
            spritex2.enabled = true;
            multiplyBy2 = true;
            
            multiplyBy3 = false;
            multiplyBy5 = false;
        }
        else if (other.gameObject.CompareTag("Multiplierx3"))
        {
            spritex3.enabled = true;
            multiplyBy3 = true;

            multiplyBy2 = false;
            multiplyBy5 = false;
        }
        else if (other.gameObject.CompareTag("Multiplierx5"))
        {
            spritex5.enabled = true;
            multiplyBy5 = true;
            
            multiplyBy2 = false;
            multiplyBy3 = false;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("10"))
        {
            AudioManager.instance.PlaySFX(scoreSound);
            RecievePoints(10);
        }
        else if (other.gameObject.CompareTag("20"))
        {
            AudioManager.instance.PlaySFX(scoreSound);
            RecievePoints(20);
        }
        else if (other.gameObject.CompareTag("30"))
        {
            AudioManager.instance.PlaySFX(scoreSound);
            RecievePoints(30);
        }
    }

    public void RecievePoints(int points)
    {
        if (multiplyBy2 == false && multiplyBy3 == false && multiplyBy5 == false)
        {
            score += points;
        }
        else if (multiplyBy2)
        {
            score += points * 2;
        }
        else if (multiplyBy3)
        {
            score += points * 3;
        }
        else if (multiplyBy5)
        {
            score += points * 5;
        }
        scoreText.text = "Score: " + score;
    }
}
