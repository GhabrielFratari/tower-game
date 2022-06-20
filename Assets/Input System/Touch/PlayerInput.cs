using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    Player player;
    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }
    void Update()
    {
        fastSwipe();
    }

    public void fastSwipe()
    {

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {

                if (Distance.x < -swipeRange)
                {
                    player.JumpLeft();
                    Debug.Log("Left");
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    player.JumpRight();
                    Debug.Log("Right");
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    player.JumpUp();
                    Debug.Log("Up");
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    player.Drop();
                    Debug.Log("Down");
                    stopTouch = true;
                }

            }

        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                Debug.Log("Tap");
            }

        }
    }
}

