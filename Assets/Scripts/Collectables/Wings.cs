using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Wings : MonoBehaviour
{
    Player player;
    MenuManager menuManager;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();
    }
    void Start()
    {
        menuManager.SpawnWingsIcon();
    }

    void Update()
    {
        player.MoveToFlyingPoint();
    }

    public void DestroyWings()
    {
        player.WingsOff();
        menuManager.DestroyWingsIcon();
        Destroy(gameObject, 0.1f);
    }
}
