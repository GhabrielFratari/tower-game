using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource[] allSounds;
    private int firstTime;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        firstTime = PlayerPrefs.GetInt("FirstTime");

        if(firstTime == 0)
        {
            SetMusic(true);
            SetSounds(true);
            SetPostProcessing(false);

            firstTime = 1;
            PlayerPrefs.SetInt("FirstTime", firstTime);
        }
    }
    public static void SetMusic(bool toggle)
    {
        if (!toggle) 
        {
            PlayerPrefs.SetInt("musicBool", 0);
        }
        else
        {
            PlayerPrefs.SetInt("musicBool", 1);
        }
    }
    public static int GetMusicBool()
    {
        return PlayerPrefs.GetInt("musicBool");
    }
    public static void SetSounds(bool toggle)
    {
        if (!toggle)
        {
            PlayerPrefs.SetInt("soundsBool", 0);
        }
        else
        {
            PlayerPrefs.SetInt("soundsBool", 1);
        }
    }

    public static int GetSounds()
    {
        return PlayerPrefs.GetInt("soundsBool");
    }

    public static void SetMode(string currentMode)
    {
        PlayerPrefs.SetString("mode", currentMode);
    }

    public static string GetMode()
    {
        return PlayerPrefs.GetString("mode");
    }
    public static void SetPostProcessing(bool toggle)
    {
        if (!toggle)
        {
            PlayerPrefs.SetInt("postProcessingBool", 0);
        }
        else
        {
            PlayerPrefs.SetInt("postProcessingBool", 1);
        }
    }

    public static int GetPostProcessing()
    {
        return PlayerPrefs.GetInt("postProcessingBool");
    }

}
