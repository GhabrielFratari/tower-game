using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinsText;

    private int points = 0;

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
        ScoreEffects();
    }

    public void AddToScore(int amount)
    {
        points += amount;
        DisplayScore();
    }

    public int GetScore()
    {
        return points;
    }

    private void ScoreEffects()
    {
        scoreText.color = Color.red;

        //500 pts - FF1600 red
        //1000 pts - DE9A18 gold
        //3000 pts - 000000 black
        //10000 pts - DEDEDE gray
    }
}
