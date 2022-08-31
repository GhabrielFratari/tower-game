using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteGame : MonoBehaviour
{
    private void Awake()
    {
        MuteSounds();
    }

    public void MuteSounds()
    {
        if (GameManager.GetSounds() == 0)
        {
            FindObjectOfType<AudioListener>().enabled = false;
        }
        else
        {
            FindObjectOfType<AudioListener>().enabled = true;
        }
    }
}
