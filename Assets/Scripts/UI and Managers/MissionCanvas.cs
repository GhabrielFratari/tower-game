using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCanvas : MonoBehaviour
{
    UISound uiSound;
    [SerializeField] Toggle[] myToggles;
    private void Awake()
    {
        for(int i = 0; i < myToggles.Length; i++)
        {
            if (SaveManager.Instance.Load().missions[i])
            {
                myToggles[i].isOn = true;
            }
        }

    }
    public void PlayUISound()
    {
        uiSound = FindObjectOfType<UISound>();
        uiSound.PlayButtonSound();
    }
}
