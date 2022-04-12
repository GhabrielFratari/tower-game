using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System;

public class DragonSpawner : MonoBehaviour
{
    [SerializeField] float outOfScreenTimer = 5f;
    [SerializeField] float onScreenTimer = 8f;
    [SerializeField] GameObject childObject;
    Vector2 outOfScreenPos;
    private bool dragonCanAppear = false;
    private bool dragonCanDisappear = false;
    void Start()
    {
        outOfScreenPos = childObject.GetComponent<Dragon>().GetOutOfScreenPos().transform.position;
        FunctionTimer.Create(DragonCanAppear, outOfScreenTimer);
    }

    void Update()
    {
        if (dragonCanAppear)
        {
            DragonAppear();
        }
        if (dragonCanDisappear)
        {
            DragonDisappear();
        }

    }

    void DragonCanAppear()
    {
        dragonCanAppear = true;
    }

    void DragonAppear()
    {
        childObject.gameObject.SetActive(true);
        childObject.GetComponent<Dragon>().CanMove();
        dragonCanAppear = false;
        FunctionTimer.Create(DragonCanDisappear, onScreenTimer);
    }

    void DragonCanDisappear()
    {
        dragonCanDisappear = true;
    }

    void DragonDisappear()
    {
        childObject.GetComponent<Dragon>().GoOutOfScreen();

        if (childObject.gameObject.transform.position.y == outOfScreenPos.y)
        {
            childObject.gameObject.SetActive(false);
            dragonCanDisappear = false;
            FunctionTimer.Create(DragonCanAppear, outOfScreenTimer);
        }
    }
}
