using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    MenuManager menuManager;
    private void Awake()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            menuManager.GameOverDelay();
        }
    }

}
