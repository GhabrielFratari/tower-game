using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wingsCostText;
    [SerializeField] private TextMeshProUGUI shieldCostText;
    [SerializeField] private TextMeshProUGUI superJumpCostText;
    [SerializeField] private TextMeshProUGUI doubleCoinCostText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] Color fillUpgradesColor;
    [SerializeField] Image SuperJumpFillUpgrade;
    [SerializeField] Image[] wingsFillUpgrade;
    [SerializeField] Image[] shieldFillUpgrade;
    [SerializeField] Image DoubleCoinFillUpgrade;

    private int[] upgradeCost = new int[] { 100, 300, 600, 1500 };

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
            for(int i = 0; i < wingsFillUpgrade.Length; i++)
            {
                if(i <= SaveManager.Instance.Load().wings)
                {
                    wingsFillUpgrade[i].color = fillUpgradesColor;
                }
            }
            
        }
        else
        { 
            wingsCostText.text = "Full";
            for (int i = 0; i < wingsFillUpgrade.Length; i++)
            {
                if (i <= SaveManager.Instance.Load().wings)
                {
                    wingsFillUpgrade[i].color = fillUpgradesColor;
                }
            }
        }
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
            for (int i = 0; i < shieldFillUpgrade.Length; i++)
            {
                if (i <= SaveManager.Instance.Load().shield)
                {
                    shieldFillUpgrade[i].color = fillUpgradesColor;
                }
            }
        }
        else 
        { 
            shieldCostText.text = "Full";
            for (int i = 0; i < shieldFillUpgrade.Length; i++)
            {
                if (i <= SaveManager.Instance.Load().shield)
                {
                    shieldFillUpgrade[i].color = fillUpgradesColor;
                }
            }
        }
    }

    public void BuySuperJump()
    {
        if (!SaveManager.Instance.isSuperJumpOwned())
        {
            SaveManager.Instance.buySuperJump(100);
        }
    }
    void UpdateSuperJumpText()
    {
        if (!SaveManager.Instance.isSuperJumpOwned())
        {
            superJumpCostText.text = "100";
        }
        else 
        { 
            superJumpCostText.text = "Full";
            SuperJumpFillUpgrade.color = fillUpgradesColor;
        }
    }
    public void BuyDoubleCoins()
    {
        if (!SaveManager.Instance.isDoubleCoinOwned())
        {
            SaveManager.Instance.buyDoubleCoin(500);
        }
    }
    void UpdateDoubleCoinText()
    {
        if (!SaveManager.Instance.isDoubleCoinOwned())
        {
            doubleCoinCostText.text = "500";
        }
        else
        { 
            doubleCoinCostText.text = "Full";
            DoubleCoinFillUpgrade.color = fillUpgradesColor;
        }
    }
}
