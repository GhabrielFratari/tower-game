using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [SerializeField] Toggle musicToggle;
    [SerializeField] Toggle modeToggle;
    [SerializeField] Toggle soundsToggle;


    bool test;

    private void Start()
    {
        if (GameManager.GetMusicBool() == 1)
        {
            musicToggle.isOn = true;
        }
        else
        {
            musicToggle.isOn = false;
        }

        if (GameManager.GetSounds() == 1)
        {
            soundsToggle.isOn = true;
        }
        else
        {
            soundsToggle.isOn = false;
        }

        if (GameManager.GetMode() == "colorBlind")
        {
            modeToggle.isOn = true;
        }
        else
        {
            modeToggle.isOn = false;
        }


    }

    public void MusicToggle(bool tog)
    {
        GameManager.SetMusic(tog);
        FindObjectOfType<MusicPlayer>().SetMusic();
    }
    public void SoundsToggle(bool tog)
    {

    }

    public void ColorBlindToggle(bool tog)
    {
        if (tog)
        {
            GameManager.SetMode("colorBlind");
        }
        else
        {
            GameManager.SetMode("standart");
        }
    }

}
