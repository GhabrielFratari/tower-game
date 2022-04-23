using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameOverMenuUI;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] float delay = 3f;

    public static bool gameIsPaused = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Playing");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void GameOver()
    {
        finalScoreText.text = "Score: " + FindObjectOfType<ScoreSystem>().GetScore().ToString();
        GameManager.SetBestScore(FindObjectOfType<ScoreSystem>().GetScore());
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOverDelay()
    {
        FunctionTimer.Create(GameOver, delay);
    }
}
