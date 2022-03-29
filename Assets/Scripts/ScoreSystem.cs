using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinsText;

    int points = 0;

    private void Awake()
    {
        
    }
    void Start()
    {
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = points.ToString();
    }

    public void AddToScore(int amount)
    {
        points += amount;
        DisplayScore();
    }
}
