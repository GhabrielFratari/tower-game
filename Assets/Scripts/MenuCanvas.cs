using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    
    void Start()
    {
        bestScoreText.text = "Best Score: " + GameManager.GetBestScore();
        coinsText.text = "Coins: " + GameManager.GetCoins();

    }

    
}
