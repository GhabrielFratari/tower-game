using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject optionsMenuUI;
    JSONsaving jsonSaving;
    private void Awake()
    {
        jsonSaving = FindObjectOfType<JSONsaving>();
    }

    void Start()
    {
        bestScoreText.text = "Best Score: " + jsonSaving.LoadData().score;
        coinsText.text = "Coins: " + jsonSaving.LoadData().coins;

    }

    public void Settings()
    {
        optionsMenuUI.SetActive(true);
    }
    
    public void ExitSettings()
    {
        optionsMenuUI.SetActive(false);
    }
    
}
