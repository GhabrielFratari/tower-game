using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    AudioSource myAudioSource;
    private void Awake()
    {
        SetUpSingleton();
        myAudioSource = GetComponent<AudioSource>();
    }
    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayButtonSound()
    {
        myAudioSource.Play();
    }
}
