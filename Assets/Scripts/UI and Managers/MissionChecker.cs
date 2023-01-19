using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionChecker : MonoBehaviour
{
    public void Mission0()
    {
        //Take 3 wings
        int index = 0;
        if (!SaveManager.Instance.Load().missions[index])
        {
            SaveManager.Instance.MissionCompleted(index);
            SaveManager.Instance.AddCoins(30);
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
            //Unlock King Bilou Skin
        }
    }
}
