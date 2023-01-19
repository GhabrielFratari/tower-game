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
    [SerializeField] GameObject shieldIcon;
    [SerializeField] GameObject wingsIcon;
    [SerializeField] GameObject iconSpawner;

    private GameObject shieldInstance;
    private GameObject wingsInstance;
    ScoreSystem scoreSystem;
    AudioSource[] allSounds;
    public static bool gameIsPaused = false;
    float currentTimeScale;
    void Awake()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        gameIsPaused = true;
        PauseAllSounds();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = currentTimeScale;
        gameIsPaused = false;
        PlayAllSounds();
    }

    public void Restart()
    {
        PlayAllSounds();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Playing");
    }

    public void LoadMenu()
    {
        PlayAllSounds();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void GameOver()
    {
        DestroyShieldIcon();
        DestroyWingsIcon();
        finalScoreText.text = "Score: " + scoreSystem.GetScore().ToString();
        //SaveManager.Instance.AddCoins(scoreSystem.GetCoins());
        SaveManager.Instance.SetBestScore(scoreSystem.GetScore());
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        PauseAllSounds();
    }
    public void PauseAllSounds()
    {
        allSounds = FindObjectsOfType<AudioSource>();
       
        foreach (AudioSource a in allSounds)
        {
            if (a != null)
            {
                a.Pause();
            }
            else
            {
                Debug.Log("Audio Source null!");
            }
        }
    }

    public void PlayAllSounds()
    {
        
        foreach (AudioSource a in allSounds)
        {
            if(a != null)
            {
                a.Play();
            }
            else
            {
                Debug.Log("Audio Source null!");
            }
        }
    }
    public void GameOverDelay()
    {
        FunctionTimer.Create(GameOver, delay);
    }

    public void SpawnShieldIcon()
    {
        shieldInstance = Instantiate(shieldIcon, iconSpawner.gameObject.transform, false);
        //-260 Y
    }
    public void DestroyShieldIcon()
    {
        if (shieldInstance != null) Destroy(shieldInstance);
    }
    public void SpawnWingsIcon()
    {
        wingsInstance = Instantiate(wingsIcon, iconSpawner.gameObject.transform, false);
        //-260 Y
    }
    public void DestroyWingsIcon()
    {
        if(wingsInstance != null) Destroy(wingsInstance);
    }
}
