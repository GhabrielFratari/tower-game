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

    string[] towers = new string[] { "MainTower", "RockTower", "WoodTower", "BoulderingTower", "PlantTower"};
    string[] outfits = new string[] { "MainOutfit", "RedKnight", "Chocolate", "Space", "Golden"};
    private int[] outfitCost = new int[] {0, 25, 50, 50, 100};
    private int[] towerCost = new int[] { 0, 1, 1, 1, 1 };
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
            selectedText.gameObject.SetActive(false);
            costText.gameObject.SetActive(true);
            costText.text = outfitCost[currentIndex].ToString();
            gameObject.GetComponent<Image>().color = yellow;
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
            selectedText.gameObject.SetActive(false);
            costText.gameObject.SetActive(true);
            costText.text = towerCost[currentIndex].ToString();
            gameObject.GetComponent<Image>().color = yellow;
        }
    }

    public void OutfitBuySelect()
    {
        if (SaveManager.Instance.isOutfitOwned(selectedOutfitIndex))
        {
            SelectOutfit(selectedOutfitIndex);
        }
        else
        {
            if(SaveManager.Instance.buyOutfit(selectedOutfitIndex, outfitCost[selectedOutfitIndex]))
            {
                SelectOutfit(selectedOutfitIndex);
            }
            else
            {
                Debug.Log("Not enough gold!");
            }
        }
    }
    public void TowerBuySelect()
    {
        if (SaveManager.Instance.isTowerOwned(selectedTowerIndex))
        {
            SelectTower(selectedTowerIndex);
        }
        else
        {
            if (SaveManager.Instance.buyTower(selectedTowerIndex, towerCost[selectedTowerIndex]))
            {
                SelectTower(selectedTowerIndex);
            }
            else
            {
                Debug.Log("Not enough gold!");
            }
        }
    }


}
