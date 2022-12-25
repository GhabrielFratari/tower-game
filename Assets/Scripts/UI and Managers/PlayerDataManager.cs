using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    PlayerData playerData;
    JSONsaving jSONsaving;
   
    public void SetTowerID(string tower)
    {
        jSONsaving = FindObjectOfType<JSONsaving>();
        CreatePlayerData(tower, jSONsaving.LoadData().outfitID, jSONsaving.LoadData().score, jSONsaving.LoadData().coins);
    }
    public void SetOutfitID(string outfit)
    {
        jSONsaving = FindObjectOfType<JSONsaving>();
        CreatePlayerData(jSONsaving.LoadData().towerID, outfit, jSONsaving.LoadData().score, jSONsaving.LoadData().coins);
    }
    public void SetScore(int score)
    {
        jSONsaving = FindObjectOfType<JSONsaving>();
        if (score > jSONsaving.LoadData().score)
        {
            CreatePlayerData(jSONsaving.LoadData().towerID, jSONsaving.LoadData().outfitID, score, jSONsaving.LoadData().coins);
        }
    }
    public void SetCoins(int coins)
    {
        jSONsaving = FindObjectOfType<JSONsaving>();
        CreatePlayerData(jSONsaving.LoadData().towerID, jSONsaving.LoadData().outfitID, jSONsaving.LoadData().score, jSONsaving.LoadData().coins + coins);
    }

    private void CreatePlayerData(string tower, string outfit, int score, int coins)
    {
        playerData = new PlayerData(tower, outfit, score, coins);
        jSONsaving.SaveData(playerData);

    }
    public PlayerData GetPlayerData()
    {
        return playerData;
    }
}
