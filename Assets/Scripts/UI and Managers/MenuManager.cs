using UnityEngine;
using UnityEngine.SceneManagement;
using CodeMonkey.Utils;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] GameObject gameOverMenuUI;
    [SerializeField] GameObject newHighScoreMenuUI;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI newHighScoreText;
    [SerializeField] float delay = 3f;
    [SerializeField] GameObject shieldIcon;
    [SerializeField] GameObject wingsIcon;
    [SerializeField] GameObject iconSpawner;
    [SerializeField] AudioClip scoreBeatenSFX;
    [SerializeField] SceneLoader sceneLoader;

    AudioSource src;
    private GameObject shieldInstance;
    private GameObject wingsInstance;
    Camera mainCam;
    ScoreSystem scoreSystem;
    AudioSource[] allSounds;
    UISound uiSound;
    public static bool gameIsPaused = false;
    float currentTimeScale;
    private int bestScore;
    private int currentScore;
    void Awake()
    {
        scoreSystem = FindObjectOfType<ScoreSystem>();
        mainCam = Camera.main;
        src = GetComponent<AudioSource>();
        bestScore = SaveManager.Instance.Load().score;
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
        sceneLoader.LoadNextScene();
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
        currentScore = scoreSystem.GetScore();
        finalScoreText.text = "Score: " + currentScore.ToString();
        //SaveManager.Instance.AddCoins(scoreSystem.GetCoins());
        
        if(bestScore >= currentScore)
        {
            gameOverMenuUI.SetActive(true);
            PauseAllSounds();
        }
        else
        {
            newHighScoreMenuUI.SetActive(true);
            newHighScoreText.text = currentScore.ToString();
            PauseAllSounds();
            AudioSource.PlayClipAtPoint(scoreBeatenSFX, mainCam.transform.position, 0.7f);
        }
        SaveManager.Instance.SetBestScore(currentScore);
        Time.timeScale = 0f;
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
    public void PlayUISound()
    {
        uiSound = FindObjectOfType<UISound>();
        uiSound.PlayButtonSound();
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
