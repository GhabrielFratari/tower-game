using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Wings : MonoBehaviour
{
    Player player;
    MenuManager menuManager;
    private int duration;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();
        CheckUpgradeState(SaveManager.Instance.Load().wings);
    }
    void Start()
    {
        menuManager.SpawnWingsIcon();
    }

    void Update()
    {
        player.MoveToFlyingPoint();
    }
    void CheckUpgradeState(int wings)
    {
        for (int i = 0; i < 4; i++)
        {
            if (wings == i)
            {
                duration = 7 + (i * 3);
            }
        }
    }

    public int GetDuration()
    {
        return duration;
    }
    public void DestroyWings()
    {
        player.WingsOff();
        menuManager.DestroyWingsIcon();
        Destroy(gameObject, 0.1f);
    }
}
