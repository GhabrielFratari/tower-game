using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] Color blue;
    [SerializeField] Color yellow;
    TextMeshProUGUI text;

    string[] towers = new string[] { "MainTower", "RockTower", "WoodTower", "BoulderingTower", "PlantTower"};
    string[] outfits = new string[] { "MainOutfit", "RedKnight", "Chocolate", "Space", "Golden"};
    private int[] outfitCost = new int[] {0, 1, 1, 1, 1};
    private int[] towerCost = new int[] { 0, 1, 1, 1, 1 };
    private int selectedOutfitIndex;
    private int selectedTowerIndex;



    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    
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
            if(SaveManager.Instance.Load().currentOutfit == outfits[currentIndex])
            {
                text.text = "Selected";
                gameObject.GetComponent<Image>().color = blue;
            }
            else
            {
                text.text = "Select";
                gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            text.text = outfitCost[currentIndex].ToString();
            gameObject.GetComponent<Image>().color = yellow;
        }
    }
    public void OnTowerSelect(int currentIndex)
    {
        selectedTowerIndex = currentIndex;

        if (SaveManager.Instance.isTowerOwned(currentIndex))
        {
            if (SaveManager.Instance.Load().currentTower == towers[currentIndex])
            {
                text.text = "Selected";
                gameObject.GetComponent<Image>().color = blue;
            }
            else
            {
                text.text = "Select";
                gameObject.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            text.text = towerCost[currentIndex].ToString();
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
