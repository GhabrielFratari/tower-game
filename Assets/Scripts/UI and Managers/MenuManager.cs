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
    PlayerDataManager playerDataMan;
    AudioSource[] allSounds;
    public static bool gameIsPaused = false;
    float currentTimeScale;
    void Awake()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        playerDataMan = FindObjectOfType<PlayerDataManager>();
    }

    public void Pause()
    {
        allSounds = FindObjectsOfType<AudioSource>();
        pauseMenuUI.SetActive(true);
        currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        gameIsPaused = true;
        foreach (AudioSource a in allSounds)
        {
            a.Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = currentTimeScale;
        gameIsPaused = false;
        foreach (AudioSource a in allSounds)
        {
            a.Play();
        }
    }

    public void Restart()
    {
        foreach (AudioSource a in allSounds)
        {
            a.Play();
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Playing");
    }

    public void LoadMenu()
    {
        foreach (AudioSource a in allSounds)
        {
            a.Play();
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void GameOver()
    {
        allSounds = FindObjectsOfType<AudioSource>();
        DestroyShieldIcon();
        DestroyWingsIcon();
        finalScoreText.text = "Score: " + scoreSystem.GetScore().ToString();
        playerDataMan.SetScore(scoreSystem.GetScore());
        playerDataMan.SetCoins(scoreSystem.GetCoins());
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        foreach (AudioSource a in allSounds)
        {
            a.Pause();
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
