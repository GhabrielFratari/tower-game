using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wingsCostText;
    [SerializeField] private TextMeshProUGUI shieldCostText;
    [SerializeField] private TextMeshProUGUI superJumpCostText;
    [SerializeField] private TextMeshProUGUI doubleCoinCostText;
    [SerializeField] private TextMeshProUGUI coinsText;

    private int[] upgradeCost = new int[] { 15, 30, 50, 100 };

    private void Update()
    {
        coinsText.text = SaveManager.Instance.Load().coins.ToString();
        UpdateWingsText();
        UpdateShieldText();
        UpdateSuperJumpText();
        UpdateDoubleCoinText();
    }
    public void BuyWings()
    {
        if (!SaveManager.Instance.isWingsOwned())
        {
            SaveManager.Instance.buyWings(upgradeCost[0]);
        }
        else if(SaveManager.Instance.Load().wings < 3)
        {
            SaveManager.Instance.buyWings(upgradeCost[SaveManager.Instance.Load().wings + 1]);
        }
    }

    void UpdateWingsText()
    {
        if (!SaveManager.Instance.isWingsOwned())
        {
            wingsCostText.text = upgradeCost[SaveManager.Instance.Load().wings].ToString();
        }
        else if(SaveManager.Instance.Load().wings < 3)
        {
            wingsCostText.text = upgradeCost[SaveManager.Instance.Load().wings + 1].ToString();
        }
        else { wingsCostText.text = "Full"; }
    }

    public void BuyShield()
    {
        if (!SaveManager.Instance.isShieldOwned())
        {
            SaveManager.Instance.buyShield(upgradeCost[0]);
        }
        else if (SaveManager.Instance.Load().shield < 3)
        {
            SaveManager.Instance.buyShield(upgradeCost[SaveManager.Instance.Load().shield + 1]);
        }
    }
    void UpdateShieldText()
    {
        if (!SaveManager.Instance.isShieldOwned())
        {
            shieldCostText.text = upgradeCost[SaveManager.Instance.Load().shield].ToString();
        }
        else if (SaveManager.Instance.Load().shield < 3)
        {
            shieldCostText.text = upgradeCost[SaveManager.Instance.Load().shield + 1].ToString();
        }
        else { shieldCostText.text = "Full"; }
    }

    public void BuySuperJump()
    {
        if (!SaveManager.Instance.isSuperJumpOwned())
        {
            SaveManager.Instance.buySuperJump(15);
        }
    }
    void UpdateSuperJumpText()
    {
        if (!SaveManager.Instance.isSuperJumpOwned())
        {
            superJumpCostText.text = "15";
        }
        else { superJumpCostText.text = "Full"; }
    }
    public void BuyDoubleCoins()
    {
        if (!SaveManager.Instance.isDoubleCoinOwned())
        {
            SaveManager.Instance.buyDoubleCoin(50);
        }
    }
    void UpdateDoubleCoinText()
    {
        if (!SaveManager.Instance.isDoubleCoinOwned())
        {
            doubleCoinCostText.text = "50";
        }
        else { doubleCoinCostText.text = "Full"; }
    }
}
