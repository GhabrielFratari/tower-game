using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    PlayerData playerData;
    string towerID;
    string outfitID;
    int scoreAmount;
    int coinsAmount;
    public void SetTowerID(string tower)
    {
        towerID = tower;
        CreatePlayerData();
    }
    public void SetOutfitID(string outfit)
    {
        outfitID = outfit;
        CreatePlayerData();
    }
    public void SetScore(int score)
    {
        scoreAmount = score;
        CreatePlayerData();
    }
    public void SetCoins(int coins)
    {
        coinsAmount = coins;
        CreatePlayerData();
    }

    private void CreatePlayerData()
    {
        playerData = new PlayerData(towerID, outfitID, scoreAmount, coinsAmount);
    }
    public PlayerData GetPlayerData()
    {
        return playerData;
    }
}
