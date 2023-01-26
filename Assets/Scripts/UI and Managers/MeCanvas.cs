using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MeCanvas : MonoBehaviour
{
    public GameObject outfitsScroll;
    public GameObject towersScroll;
    [SerializeField] Color buttonCollor;
    [SerializeField] Button towersButton;
    [SerializeField] Button outfitsButton;
    [SerializeField] TextMeshProUGUI coinsText;
    UISound uiSound;

    private void Update()
    {
        coinsText.text = SaveManager.Instance.Load().coins.ToString();

        if (outfitsScroll.activeInHierarchy)
        {
            outfitsButton.transform.localScale = Vector2.Lerp(outfitsButton.transform.localScale, new Vector2(1f, 1f), 0.1f);
            towersButton.transform.localScale = Vector2.Lerp(towersButton.transform.localScale, new Vector2(0.8f, 0.8f), 0.1f);
        }
        else
        {
            towersButton.transform.localScale = Vector2.Lerp(towersButton.transform.localScale, new Vector2(1f, 1f), 0.1f);
            outfitsButton.transform.localScale = Vector2.Lerp(outfitsButton.transform.localScale, new Vector2(0.8f, 0.8f), 0.1f);
        }
    }
    public void OutfitsButton()
    {
        if (!outfitsScroll.activeInHierarchy)
        {
            outfitsScroll.SetActive(true);
            towersScroll.SetActive(false);
            outfitsButton.image.color = Color.white;
            towersButton.image.color = buttonCollor;            
        }
    }
    public void TowersButton()
    {
        if (!towersScroll.activeInHierarchy)
        {
            towersScroll.SetActive(true);
            outfitsScroll.SetActive(false);
            towersButton.image.color = Color.white;
            outfitsButton.image.color = buttonCollor;
        }
    }
    public void PlayUISound()
    {
        uiSound = FindObjectOfType<UISound>();
        uiSound.PlayButtonSound();
    }
}
