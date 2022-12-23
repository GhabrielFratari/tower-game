using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitTowerSelect : MonoBehaviour
{
    string towerID;
    string outfitID;
    JSONsaving jsonSaving;
    PlayerDataManager playerDataManager;
    
    private void Awake()
    {
        jsonSaving = FindObjectOfType<JSONsaving>();
        playerDataManager = FindObjectOfType<PlayerDataManager>();
    }


    public void SelectTower()
    {
        towerID = FindObjectOfType<SwipeMenu>().GetTowerID();
        //Debug.Log(towerID);
        playerDataManager.SetTowerID(towerID);


        jsonSaving.SaveData(playerDataManager.GetPlayerData());
    }
    
}
