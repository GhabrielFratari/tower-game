using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static void SetBestScore(int score)
    {
        if (score > PlayerPrefs.GetInt("bestScore"))
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
    }
    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt("bestScore");
    }
    public static void SetCoins(int amount)
    {
        PlayerPrefs.SetInt("coins", GetCoins() + amount);
    }
    public static int GetCoins()
    {
        return PlayerPrefs.GetInt("coins");
    }
}
