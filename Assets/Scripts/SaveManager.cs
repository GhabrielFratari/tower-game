using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(Helper.Serialize<SaveState>(state));
        Debug.Log(isTowerOwned(4));
        UnlockTower(4);
        Debug.Log(isTowerOwned(4));

    }

    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    public SaveState Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
            return state;
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save file found, creating a new one!");
            return state;
        }
    }

    public bool isTowerOwned(int index)
    {
        return (state.towerOwned & (1 << index)) != 0;
    }
    public bool isOutfitOwned(int index)
    {
        return (state.outfitOwned & (1 << index)) != 0;
    }

    public bool buyTower(int index, int cost)
    {
        if(state.coins >= cost)
        {
            state.coins -= cost;
            UnlockTower(index);
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool buyOutfit(int index, int cost)
    {
        if (state.coins >= cost)
        {
            state.coins -= cost;
            UnlockOutfit(index);
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UnlockTower(int index)
    {
        state.towerOwned |= 1 << index;
    }
    public void UnlockOutfit(int index)
    {
        state.outfitOwned |= 1 << index;
    }

    public void AddCoins(int coins)
    {
        state.coins += coins;
        Save();
    }

    public void SetBestScore(int bestScore)
    {
        state.score = bestScore;
        Save();
    }

    public void ResetSave()
    {
        PlayerPrefs.DeleteKey("save");
    }
}
