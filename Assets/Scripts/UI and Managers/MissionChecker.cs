using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionChecker : MonoBehaviour
{
    ScoreSystem myScoreSystem;
    private void Awake()
    {
        myScoreSystem = FindObjectOfType<ScoreSystem>();
    }

    public void Mission0()
    {
        //Take 3 wings
        int index = 0;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(30);
            myScoreSystem.MissionPopUp("Take 3 wings!");
        }
    }
    public void Mission1()
    {
        //Take 3 shields
        int index = 1;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(30);
            myScoreSystem.MissionPopUp("Take 3 shields!");
        }
    }
    public void Mission2()
    {
        //Take 3 super jumps
        int index = 2;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(30);
            myScoreSystem.MissionPopUp("Take 3 Super Jumps!");
        }
    }
    public void Mission3()
    {
        //Take 5 wings
        int index = 3;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(100);
            myScoreSystem.MissionPopUp("Take 5 wings!");
        }
    }
    public void Mission4()
    {
        //Take 5 shields
        int index = 4;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(100);
            myScoreSystem.MissionPopUp("Take 5 shields!");
        }
    }
    public void Mission5()
    {
        //Take 5 super jumps
        int index = 5;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(100);
            myScoreSystem.MissionPopUp("Take 5 Super Jumps!");
        }
    }
    public void Mission6()
    {
        //Hit 100 points
        int index = 6;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(10);
            myScoreSystem.MissionPopUp("Hit 100 points!");
        }
    }
    public void Mission7()
    {
        //Hit 500 points
        int index = 7;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(50);
            myScoreSystem.MissionPopUp("Hit 500 points!");
        }
    }
    public void Mission8()
    {
        //Hit 1000 points
        int index = 8;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(100);
            myScoreSystem.MissionPopUp("Hit 1000 points!");
        }
    }
    public void Mission9()
    {
        //Hit 3000 points
        int index = 9;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(300);
            SaveManager.Instance.buyOutfit(4, 0);
            myScoreSystem.MissionPopUp("Hit 3000 points!");
            //Unlock GoldSkin
        }
    }
    public void Mission10()
    {
        //Hit 5000 points
        int index = 10;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(500);
            myScoreSystem.MissionPopUp("Hit 5000 points!");
        }
    }
    public void Mission11()
    {
        //Hit 10000 points
        int index = 11;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(1000);
            myScoreSystem.MissionPopUp("Hit 10000 points!");
            //Unlock King Bilou Skin
        }
    }
    public void Mission12()
    {
        //Hit 30000 points
        int index = 12;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(1000);
            SaveManager.Instance.buyTower(5, 0);
            myScoreSystem.MissionPopUp("Hit 30000 points!");
            //Unlock old tower 
        }
    }
    public void Mission13()
    {
        //Hit 50000 points
        int index = 13;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(1000);
            SaveManager.Instance.buyOutfit(6, 0);
            myScoreSystem.MissionPopUp("Hit 50000 points!");
            //Unlock Sketch Skin
        }
    }
}
