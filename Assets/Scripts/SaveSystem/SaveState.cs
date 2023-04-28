public class SaveState
{
    public int towerOwned = 1; // 0000 0000
    public int outfitOwned = 1;
    public string currentTower = "MainTower";
    public string currentOutfit = "MainOutfit";
    public int coins = 0;
    public int score = 0;
    public int wings = 0;
    public int shield = 0;
    public bool superJump = false;
    public bool doubleCoin = false;
    public bool wingsOwned = false;
    public bool shieldOwned = false;
    public bool[] missions = { false, false, false, false, false, false, false, false, false, false, false, false, false, false };
}
