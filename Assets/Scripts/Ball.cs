using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private bool springTouched = false;
    [SerializeField] float springForce;
    
    private int multiplier;
    
    void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (springTouched && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * springForce,  ForceMode2D.Impulse);
            springTouched = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spring"))
        {
            springTouched = true;
        }
    }

    
}
