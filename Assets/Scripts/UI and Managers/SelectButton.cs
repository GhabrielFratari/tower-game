using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] Color blue;
    [SerializeField] Color yellow;
    [SerializeField] Color mainColor;
    [SerializeField] GameObject coinImage;
    [SerializeField] RectTransform textPos;
    [SerializeField] TextMeshProUGUI selectedText;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] AudioClip buySound;
    [SerializeField] AudioClip failSound;
    UISound selectSound;

    string[] towers = new string[] { "MainTower", "RockTower", "WoodTower", "BoulderingTower", "PlantTower", "OldTower"};
    string[] outfits = new string[] { "MainOutfit", "RedKnight", "Chocolate", "Space", "Golden", "Astronaut", "Sketch"};
    private int[] outfitCost = new int[] {0, 200, 500, 500, 10000, 1000, 10000};
    private int[] towerCost = new int[] { 0, 1000, 1000, 1000, 1000, 10000};
    private int selectedOutfitIndex;
    private int selectedTowerIndex;

    private void SelectOutfit(int index)
    {
        SaveManager.Instance.ChangeOutfit(outfits[index]);
    }
    private void SelectTower(int index)
    {
        SaveManager.Instance.ChangeTower(towers[index]);
    }

    public void OnOutfitSelect(int currentIndex)
    {
        selectedOutfitIndex = currentIndex;

        if (SaveManager.Instance.isOutfitOwned(currentIndex))
        {
            selectedText.gameObject.SetActive(true);
            costText.gameObject.SetActive(false);

            if (SaveManager.Instance.Load().currentOutfit == outfits[currentIndex])
            {
                selectedText.text = "Selected";
                gameObject.GetComponent<Image>().color = blue;
            }
            else
            {
                selectedText.text = "Select";
                gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            if(currentIndex == 4 || currentIndex == 6)
            {
                selectedText.gameObject.SetActive(true);
                costText.gameObject.SetActive(false);
                selectedText.text = "Locked";
                gameObject.GetComponent<Image>().color = Color.grey;
            }
            else
            {
                selectedText.gameObject.SetActive(false);
                costText.gameObject.SetActive(true);
                costText.text = outfitCost[currentIndex].ToString();
                gameObject.GetComponent<Image>().color = yellow;
            }
        }
    }
    public void OnTowerSelect(int currentIndex)
    {
        selectedTowerIndex = currentIndex;

        if (SaveManager.Instance.isTowerOwned(currentIndex))
        {
            selectedText.gameObject.SetActive(true);
            costText.gameObject.SetActive(false);

            if (SaveManager.Instance.Load().currentTower == towers[currentIndex])
            {
                selectedText.text = "Selected";
                gameObject.GetComponent<Image>().color = blue;
            }
            else
            {
                selectedText.text = "Select";
                gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            if(currentIndex == 5)
            {
                selectedText.gameObject.SetActive(true);
                costText.gameObject.SetActive(false);
                selectedText.text = "Locked";
                gameObject.GetComponent<Image>().color = Color.grey;
            }
            else
            {
                selectedText.gameObject.SetActive(false);
                costText.gameObject.SetActive(true);
                costText.text = towerCost[currentIndex].ToString();
                gameObject.GetComponent<Image>().color = yellow;
            }
        }
    }

    public void OutfitBuySelect()
    {
        if (SaveManager.Instance.isOutfitOwned(selectedOutfitIndex))
        {
            SelectOutfit(selectedOutfitIndex);
            PlaySelectSound();
        }
        else
        {
            if(SaveManager.Instance.buyOutfit(selectedOutfitIndex, outfitCost[selectedOutfitIndex]))
            {
                SelectOutfit(selectedOutfitIndex);
                PlayBuySound();
            }
            else
            {
                Debug.Log("Not enough gold!");
                PlayFailSound();
            }
        }
    }
    public void TowerBuySelect()
    {
        if (SaveManager.Instance.isTowerOwned(selectedTowerIndex))
        {
            SelectTower(selectedTowerIndex);
            PlaySelectSound();
        }
        else
        {
            if (SaveManager.Instance.buyTower(selectedTowerIndex, towerCost[selectedTowerIndex]))
            {
                SelectTower(selectedTowerIndex);
                PlayBuySound();
            }
            else
            {
                Debug.Log("Not enough gold!");
                PlayFailSound();
            }
        }
    }

    public void PlaySelectSound()
    {
        selectSound = FindObjectOfType<UISound>();
        selectSound.PlayButtonSound();
    }
    public void PlayBuySound()
    {
        if(buySound != null)
        {
            AudioSource.PlayClipAtPoint(buySound, Camera.main.transform.position, 0.7f);

        }
    }
    public void PlayFailSound()
    {
        if (failSound != null)
        {
            AudioSource.PlayClipAtPoint(failSound, Camera.main.transform.position, 0.7f);

        }
    }
}
