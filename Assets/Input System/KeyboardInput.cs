using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KeyboardInput : MonoBehaviour
{
    Player player;
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    void OnJumpUp(InputValue value)
    {
        if (value.isPressed)
        {
            player.JumpUp();
        }
    }
    void OnJumpRight(InputValue value)
    {
        if (value.isPressed)
        {
            player.JumpRight();
        }
    }
    void OnJumpLeft(InputValue value)
    {
        if (value.isPressed)
        {
            player.JumpLeft();
        }
    }
    void OnDrop(InputValue value)
    {
        if (value.isPressed)
        {
            player.Drop();
        }
    }
}
