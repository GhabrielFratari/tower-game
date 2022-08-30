using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteGame : MonoBehaviour
{
    private void Awake()
    {
        if(GameManager.GetSounds() == 0)
        {
            FindObjectOfType<AudioListener>().enabled = false;
        }
        else
        {
            FindObjectOfType<AudioListener>().enabled = true;
        }
    }
}
