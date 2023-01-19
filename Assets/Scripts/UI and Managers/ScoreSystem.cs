using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CodeMonkey.Utils;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] GameObject flash;
    [SerializeField] AudioClip scoreSound;
    [SerializeField] Color red;
    [SerializeField] Color gold;
    [SerializeField] Color gray;

    private int points = 0;
    private int coins = 0;
    private bool canChangeColorRed = true;
    private bool canChangeColorGold = true;
    private bool canChangeColorBlack = true;
    private bool canChangeColorGray = true;
    Camera mainCamera;
    MissionChecker missionChecker;

    private void Awake()
    {
        mainCamera = Camera.main;
        missionChecker = FindObjectOfType<MissionChecker>();
    }
    void Start()
    {
        //Application.targetFrameRate = 60;
        DisplayScore();
        DisplayCoins();
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
        CheckMission();
    }
    public void AddCoins(int amount)
    {
        coins += amount;
        DisplayCoins();
    }
    private void DisplayCoins()
    {
        coinsText.text = coins.ToString();
    }

    public int GetCoins()
    {
        return coins;
    }

    public int GetScore()
    {
        return points;
    }

    private void ScoreEffects()
    {
        //500 pts - FF1600 red
        //1000 pts - DE9A18 gold
        //3000 pts - 000000 black
        //10000 pts - DEDEDE gray
        if (points >= 500 && points < 1000 && canChangeColorRed)
        {
            flash.SetActive(true);
            FunctionTimer.Create(DisableFlash, 2f);
            scoreText.color = red;
            AudioSource.PlayClipAtPoint(scoreSound, mainCamera.transform.position, 0.5f);
            canChangeColorRed = false;
        }
        else if (points >= 1000 && points < 3000 && canChangeColorGold)
        {
            flash.SetActive(true);
            FunctionTimer.Create(DisableFlash, 2f);
            scoreText.color = gold;
            AudioSource.PlayClipAtPoint(scoreSound, mainCamera.transform.position, 0.5f);
            canChangeColorGold = false;
        }
        else if(points >= 3000 && points < 10000 && canChangeColorBlack)
        {
            flash.SetActive(true);
            FunctionTimer.Create(DisableFlash, 2f);
            scoreText.color = Color.black;
            AudioSource.PlayClipAtPoint(scoreSound, mainCamera.transform.position, 0.5f);
            canChangeColorBlack = false;
        }
        else if (points >= 10000 && canChangeColorGray)
        {
            flash.SetActive(true);
            FunctionTimer.Create(DisableFlash, 2f);
            scoreText.color = gray;
            AudioSource.PlayClipAtPoint(scoreSound, mainCamera.transform.position, 0.5f);
            canChangeColorGray = false;
        }

        void DisableFlash()
        {
            flash.SetActive(false);
        }
    }

    void CheckMission()
    {
        if(points >= 100 && !SaveManager.Instance.Load().missions[6])
        {
            missionChecker.Mission6();
        }
        else if(points >= 500 && !SaveManager.Instance.Load().missions[7])
        {
            missionChecker.Mission7();
        }
        else if (points >= 1000 && !SaveManager.Instance.Load().missions[8])
        {
            missionChecker.Mission8();
        }
        else if (points >= 3000 && !SaveManager.Instance.Load().missions[9])
        {
            missionChecker.Mission9();
        }
        else if (points >= 5000 && !SaveManager.Instance.Load().missions[10])
        {
            missionChecker.Mission10();
        }
        else if (points >= 10000 && !SaveManager.Instance.Load().missions[11])
        {
            missionChecker.Mission11();
        }
    }
    
}
