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
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;

        }
    }
}
