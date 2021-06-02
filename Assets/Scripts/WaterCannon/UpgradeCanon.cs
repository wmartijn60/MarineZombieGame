using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeCanon : MonoBehaviour
{
    [SerializeField] private int maxLevel = 3;
    [SerializeField] private SpriteRenderer canon;
    [SerializeField] private SpriteRenderer canonHinge;
    [SerializeField] private Animator upgradeVFX;

    [SerializeField] private TextMeshProUGUI capacityPrize;
    [SerializeField] private TextMeshProUGUI rechargePrize;
    [SerializeField] private TextMeshProUGUI repressurePrize;
    [SerializeField] private TextMeshProUGUI allPrize;

    [SerializeField] private WaterPressure waterPressure;
    [SerializeField] private List<int> upgradeCost;
    [SerializeField] private List<int> upgradeCostAll;
    [SerializeField] private List<int> upgradeCapacity;
    [SerializeField] private List<int> upgradeRecharge;
    [SerializeField] private List<int> upgradeRepressure;
    [SerializeField] private List<int> upgradeLevel;
    [SerializeField] private List<Sprite> canonUpgrades;
    [SerializeField] private List<Sprite> canonHingeUpgrades;

    void Start()
    {              
        allPrize.text = upgradeCostAll[upgradeLevel[3]].ToString();
    }

    public void UpgradeCapacity()
    {
        if (maxLevel != upgradeLevel[0] && GameManager.Coins >= upgradeCost[upgradeLevel[0]])
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
        if (maxLevel != upgradeLevel[1] && GameManager.Coins >= upgradeCost[upgradeLevel[1]])
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
        if (maxLevel != upgradeLevel[2] && GameManager.Coins >= upgradeCost[upgradeLevel[2]])
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

    public void UpgradeAll()
    {
        if (maxLevel != upgradeLevel[3] && GameManager.Coins >= upgradeCostAll[upgradeLevel[3]])
        {
            GameManager.ChangeCoinAmount(-upgradeCostAll[upgradeLevel[3]]);
            upgradeVFX.SetTrigger("UpgradeCanon");
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX One-Shots/Upgrade", GetComponent<Transform>().position);
            waterPressure.IncreaseCapacity(upgradeCapacity[upgradeLevel[0]]);
            waterPressure.IncreaseRechargeRate(upgradeRecharge[upgradeLevel[1]]);
            waterPressure.SetRepressureValue(upgradeRepressure[upgradeLevel[2]]);
            upgradeLevel[0] += 1;
            upgradeLevel[1] += 1;
            upgradeLevel[2] += 1;
            upgradeLevel[3] += 1;
            if (upgradeLevel[3] == maxLevel)
            {
                allPrize.text = "max";
                canon.sprite = canonUpgrades[upgradeLevel[3] - 1];
                canonHinge.sprite = canonHingeUpgrades[upgradeLevel[3] - 1];
            }
            else
            {
                allPrize.text = upgradeCostAll[upgradeLevel[3]].ToString();
                canon.sprite = canonUpgrades[upgradeLevel[3] -1];
                canonHinge.sprite = canonHingeUpgrades[upgradeLevel[3]-1];
            }
        }
    }
}
