using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10;
    [SerializeField] float speedMultiplier = 0.1f;
    public float gameSpeed;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        IncreaseSpeed();
    }

    void IncreaseSpeed()
    {
        if(Time.timeScale <= maxSpeed)
        {
            Time.timeScale += speedMultiplier;
            gameSpeed = Time.timeScale;
        }
    }
}
