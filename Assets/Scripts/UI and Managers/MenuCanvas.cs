using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject optionsMenuUI;

    UISound uiSound;
   

    void Start()
    {
        bestScoreText.text = "Best Score: " + SaveManager.Instance.Load().score;
        coinsText.text = SaveManager.Instance.Load().coins.ToString();

    }

    public void Settings()
    {
        optionsMenuUI.SetActive(true);
    }
    
    public void ExitSettings()
    {
        optionsMenuUI.SetActive(false);
    }
    
    public void PlayUISound()
    {
        uiSound = FindObjectOfType<UISound>();
        uiSound.PlayButtonSound();
    }
}
