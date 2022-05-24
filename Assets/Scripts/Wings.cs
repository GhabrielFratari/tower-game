using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Wings : MonoBehaviour
{
    [SerializeField] private float duration;

    Player player;
    MenuManager menuManager;
    void Start()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();
        menuManager.SpawnWingsIcon();
        FunctionTimer.Create(DestroyWings, duration);
    }

    void Update()
    {
        player.MoveToFlyingPoint();
    }

    void DestroyWings()
    {
        player.WingsOff();
        Destroy(gameObject, 0.1f);
    }

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }
   
}
