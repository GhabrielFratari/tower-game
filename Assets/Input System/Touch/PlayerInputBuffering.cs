using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputBuffering : MonoBehaviour
{
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounterLeft; 
    private float jumpBufferCounterRight; 
    private float jumpBufferCounterUp; 

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
                //jumping left
                if (Distance.x < -swipeRange)
                {
                    jumpBufferCounterLeft = jumpBufferTime;
                    Debug.Log("Left");
                    stopTouch = true;
                }
                else
                {
                    jumpBufferCounterLeft -= Time.unscaledDeltaTime;
                }
                if(jumpBufferCounterLeft > 0f && player.handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
                {
                    player.JumpLeft();
                    jumpBufferCounterLeft = 0f;
                }


                //jumping right
                if (Distance.x > swipeRange)
                {
                    jumpBufferCounterRight = jumpBufferTime;
                    Debug.Log("Right");
                    stopTouch = true;
                }
                else
                {
                    jumpBufferCounterRight -= Time.unscaledDeltaTime;
                }
                if(jumpBufferCounterRight > 0f && player.handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
                {
                    player.JumpRight();
                    jumpBufferCounterRight = 0f;
                }


                //jumping up
                if (Distance.y > swipeRange)
                {
                    jumpBufferCounterUp = jumpBufferTime;
                    Debug.Log("Up");
                    stopTouch = true;
                }
                else
                {
                    jumpBufferCounterUp -= Time.unscaledDeltaTime;
                }
                if(jumpBufferCounterUp > 0f && player.handsCollider.IsTouchingLayers(LayerMask.GetMask("stones")))
                {
                    player.JumpUp();
                    jumpBufferCounterUp = 0f;
                }

                if (Distance.y < -swipeRange)
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

