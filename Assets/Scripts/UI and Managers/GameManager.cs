using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource[] allSounds;
 
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
}
