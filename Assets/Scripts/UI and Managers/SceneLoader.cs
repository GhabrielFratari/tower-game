using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void LoadNextScene()
    {
        if(GameManager.GetMode() == "colorBlind")
        {
            LoadColorBlindScene();
        }
        else
        {
            LoadPlayScene();
        }
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("Playing");
    }

    public void LoadColorBlindScene()
    {
        SceneManager.LoadScene("Color Blind");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMeScene()
    {
        SceneManager.LoadScene("Me");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
