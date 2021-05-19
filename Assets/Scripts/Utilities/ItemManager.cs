using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{   
    public static ItemManager Instance;

    [SerializeField]private int startCoins = 100;
    [SerializeField]private int balloonCost;
    [SerializeField]private int mineCost;
    [SerializeField]private int wallCost;

    [SerializeField] private TextMeshProUGUI balloonsTotal;
    [SerializeField] private TextMeshProUGUI balloonPrizetag;
    [SerializeField] private TextMeshProUGUI minePrizetag;
    [SerializeField] private TextMeshProUGUI wallPrizetag;

    [SerializeField] private bool debugCoins;

    private FmodPlayer fmodPlayer;

    public int balloonAmount;

    void Awake()
    {
        if (ItemManager.Instance == null)
            ItemManager.Instance = this;
        else
            Destroy(this.gameObject);

        fmodPlayer = GetComponent<FmodPlayer>();
    }

    void Start()
    {
        balloonPrizetag.text = balloonCost.ToString();
        minePrizetag.text = mineCost.ToString();
        wallPrizetag.text = wallCost.ToString();
        UpdateBalloonCount();
        if (debugCoins)
        {
            GameManager.ChangeCoinAmount(9999);
        }
        else
        {
            GameManager.ChangeCoinAmount(startCoins);
        }
        
    }

    public void BuyBalloon()
    {
        if (GameManager.Coins >= balloonCost)
        {
            
            GameManager.ChangeCoinAmount(-balloonCost);
            fmodPlayer.PlaySound("event:/Purchase");
            balloonAmount++;
            UpdateBalloonCount();
        }
        else
            fmodPlayer.PlaySound("event:/NotEnoughMoney");
    }

    public void BuyMine()//may be outdated
    {
        if (GameManager.Coins >= mineCost)
        {
            GameManager.ChangeCoinAmount(-mineCost);
            fmodPlayer.PlaySound("event:/Purchase");
        }
        else
            fmodPlayer.PlaySound("event:/NotEnoughMoney");
    }

    public void BuyWall()//may be outdated
    {
        if (GameManager.Coins >= balloonCost)
        {
            GameManager.ChangeCoinAmount(-wallCost);
            fmodPlayer.PlaySound("event:/Purchase");
        }
        else
            fmodPlayer.PlaySound("event:/NotEnoughMoney");
    }

    public void BuyItem(int cost)
    {
        if (GameManager.Coins >= cost)
        {
            GameManager.ChangeCoinAmount(cost);
            fmodPlayer.PlaySound("event:/Purchase");
        }
        else
            fmodPlayer.PlaySound("event:/NotEnoughMoney");
    }

    public bool CanAfford(int cost)
    {
        if (GameManager.Coins >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UseBalloon()
    {
        if (balloonAmount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdateBalloonCount()
    {
        balloonsTotal.text = balloonAmount.ToString();
    }

}
