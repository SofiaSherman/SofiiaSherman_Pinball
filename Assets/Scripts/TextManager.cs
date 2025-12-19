using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField] TMP_Text HighScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HighScoreText.text = "High Score: " + GameManager.instance.HighScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
