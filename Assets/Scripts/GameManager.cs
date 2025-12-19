using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score { get; set; } = 0;
    public int HighScore { get; set; } = 0;
    
    public static GameManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetScore(int score)
    {
        Score = score;
    }

    public void SetHighScore(int score)
    {
        HighScore = score;
    }
}
