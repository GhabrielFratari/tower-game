using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class DragonSpawner : MonoBehaviour
{
    [SerializeField] float outOfScreenMinTime = 5f;
    [SerializeField] float outOfScreenMaxTime = 5f;
    [SerializeField] float onScreenMinTime = 8f;
    [SerializeField] float onScreenMaxTime = 8f;
    [SerializeField] GameObject childObject;
    Vector2 outOfScreenPos;
    private bool dragonCanAppear = false;
    private bool dragonCanDisappear = false;
    void Start()
    {
        outOfScreenPos = childObject.GetComponent<Dragon>().GetOutOfScreenPos().transform.position;
        FunctionTimer.Create(DragonCanAppear, outOfScreenMinTime);
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
        FunctionTimer.Create(DragonCanDisappear, RandomizeTimer(onScreenMinTime, onScreenMaxTime));
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
            FunctionTimer.Create(DragonCanAppear, RandomizeTimer(outOfScreenMinTime, outOfScreenMaxTime));
        }
    }

    float RandomizeTimer(float minTime, float maxTime)
    {
        float randomTime = Random.Range(minTime, maxTime);

        return randomTime;
    }
}
