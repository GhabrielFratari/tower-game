using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData 
{
    public string towerID;
    public string outfitID;
    public int score;
    public int coins;

    public PlayerData(string towerID, string outfitID, int score, int coins)
    {
        this.towerID = towerID;
        this.outfitID = outfitID;
        this.score = score;
        this.coins = coins;
    }
    
    public override string ToString()
    {
        return $"At {towerID} with {outfitID}  with {score} score. They have reached {coins} coins";
    }

}
