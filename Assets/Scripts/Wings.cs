using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Wings : MonoBehaviour
{
    Player player;
    MenuManager menuManager;
    void Start()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();
        menuManager.SpawnWingsIcon();
    }

    void Update()
    {
        player.MoveToFlyingPoint();
    }

    public void DestroyWings()
    {
        player.WingsOff();
        Destroy(gameObject, 0.1f);
    }
}
