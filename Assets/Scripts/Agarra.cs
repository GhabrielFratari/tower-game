﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarra : MonoBehaviour
{
    public static float speed = 3.4f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void FixedUpdate()
    {
        //print(speed);
        rb.velocity = new Vector2(0, -speed);
        speed += 0.00009555f;
        if (transform.position.y < -screenBounds.y * 4)
        {
            Destroy(this.gameObject);
        }
    }
}
