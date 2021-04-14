using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCanon : MonoBehaviour
{
    [SerializeField]private int maxLevel = 3;

    [SerializeField]private TextMeshProUGUI capacityPrize;
    [SerializeField]private TextMeshProUGUI rechargePrize;
    [SerializeField]private TextMeshProUGUI repressurePrize;

    [SerializeField] private WaterPressure waterPressure;
    [SerializeField] private List<int> upgradeCost;
    [SerializeField] private List<int> upgradeCapacity;
    [SerializeField] private List<int> upgradeRecharge;
    [SerializeField] private List<int> upgradeRepressure;
    [SerializeField] private List<int> upgradeLevel;

    void Start()
    {
        capacityPrize.text = upgradeCost[upgradeLevel[0]].ToString();
        rechargePrize.text = upgradeCost[upgradeLevel[1]].ToString();
        repressurePrize.text = upgradeCost[upgradeLevel[2]].ToString();
    }


    public void UpgradeCapacity()
    {
        if (GameManager.Coins >= upgradeCost[0] && maxLevel != upgradeLevel[0])
        {
            GameManager.ChangeCoinAmount(-upgradeCost[upgradeLevel[0]]);
            waterPressure.IncreaseCapacity(upgradeCapacity[upgradeLevel[0]]);
            upgradeLevel[0] += 1;
            if (upgradeLevel[0] == maxLevel)
            {
                capacityPrize.text = "max";
            }
            else
            {
                capacityPrize.text = upgradeCost[upgradeLevel[0]].ToString();
            }
            
        }
    }

    public void UpgradeRecharge()
    {
        if (GameManager.Coins >= upgradeCost[1] && maxLevel != upgradeLevel[1])
        {
            GameManager.ChangeCoinAmount(-upgradeCost[upgradeLevel[1]]);
            waterPressure.IncreaseRechargeRate(upgradeRecharge[upgradeLevel[1]]);
            upgradeLevel[1] += 1;
            if (upgradeLevel[1] == maxLevel)
            {
                rechargePrize.text = "max";
            }
            else
            {
                rechargePrize.text = upgradeCost[upgradeLevel[1]].ToString();
            }
            
        }
    }

    public void UpgradeRepressure()
    {
        if (GameManager.Coins >= upgradeCost[2] && maxLevel != upgradeLevel[2])
        {
            GameManager.ChangeCoinAmount(-upgradeCost[upgradeLevel[2]]);
            waterPressure.SetRepressureValue(upgradeRepressure[upgradeLevel[2]]);
            upgradeLevel[2] += 1;
            if (upgradeLevel[2] == maxLevel)
            {
                repressurePrize.text = "max";
            }
            else
            {
                repressurePrize.text = upgradeCost[upgradeLevel[2]].ToString();
            }
            
        }
    }

}
