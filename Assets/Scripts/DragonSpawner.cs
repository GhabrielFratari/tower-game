using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


public class DragonSpawner : MonoBehaviour
{
    [SerializeField] float outOfScreenTime = 5f;
    [SerializeField] float outOfScreenMinTime = 5f;
    [SerializeField] float outOfScreenMaxTime = 5f;
    [SerializeField] float onScreenMinTime = 8f;
    [SerializeField] float onScreenMaxTime = 8f;
    [SerializeField] GameObject childObject;
    Vector2 outOfScreenPos;
    Dragon dragon;
    private bool dragonCanAppear = false;
    private bool dragonCanDisappear = false;
    private void Awake()
    {
        outOfScreenPos = childObject.GetComponent<Dragon>().GetOutOfScreenPos().transform.position;
        dragon = childObject.GetComponent<Dragon>();
    }
    void Start()
    {
        FunctionTimer.Create(DragonCanAppear, outOfScreenTime);
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
        dragon.CanMove();
        dragonCanAppear = false;
        FunctionTimer.Create(DragonCanDisappear, RandomizeTimer(onScreenMinTime, onScreenMaxTime));
    }

    void DragonCanDisappear()
    {
        dragonCanDisappear = true;
    }

    void DragonDisappear()
    {
        dragon.GoOutOfScreen();

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
