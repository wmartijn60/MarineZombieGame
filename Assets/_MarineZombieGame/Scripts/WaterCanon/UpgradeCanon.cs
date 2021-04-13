using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCanon : MonoBehaviour
{
    [SerializeField]private int maxLevel = 3;

    [SerializeField] private WaterPressure waterPressure;
    [SerializeField] private List<int> upgradeCost;
    [SerializeField] private List<int> upgradeCapacity;
    [SerializeField] private List<int> upgradeRecharge;
    [SerializeField] private List<int> upgradeRepressure;
    [SerializeField] private List<int> upgradeLevel;

    void Start()
    {
        
    }


    public void UpgradeCapacity()
    {
        if (GameManager.Coins >= upgradeCost[0] && maxLevel != upgradeLevel[0])
        {
            GameManager.ChangeCoinAmount(-upgradeCost[0]);
            waterPressure.IncreaseCapacity(upgradeCapacity[upgradeLevel[0]]);
            upgradeLevel[0] += 1;            
        }
    }

    public void UpgradeRecharge()
    {
        if (GameManager.Coins >= upgradeCost[1] && maxLevel != upgradeLevel[1])
        {
            GameManager.ChangeCoinAmount(-upgradeCost[1]);
            waterPressure.IncreaseRechargeRate(upgradeRecharge[upgradeLevel[1]]);
            upgradeLevel[1] += 1;
        }
    }

    public void UpgradeRepressure()
    {
        if (GameManager.Coins >= upgradeCost[2] && maxLevel != upgradeLevel[2])
        {
            GameManager.ChangeCoinAmount(-upgradeCost[2]);
            waterPressure.SetRepressureValue(upgradeRepressure[upgradeLevel[2]]);
            upgradeLevel[2] += 1;
        }
    }

}
