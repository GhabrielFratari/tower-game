using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsCanvas : MonoBehaviour
{
    UISound uiSound;

    public void PlayUISound()
    {
        uiSound = FindObjectOfType<UISound>();
        uiSound.PlayButtonSound();
    }
}
