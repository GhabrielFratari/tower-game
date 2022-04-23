using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;
    private void Awake()
    {
        
    }
    void Start()
    {
        bestScoreText.text = "Best Score: " + GameManager.GetBestScore();

    }

    void Update()
    {

    }
}
