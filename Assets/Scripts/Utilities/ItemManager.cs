using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{   
    [SerializeField]private int balloonCost;
    [SerializeField]private int mineCost;
    [SerializeField]private int wallCost;

    [SerializeField] private TextMeshProUGUI balloonsTotal;
    [SerializeField] private TextMeshProUGUI balloonPrizetag;
    [SerializeField] private TextMeshProUGUI minePrizetag;
    [SerializeField] private TextMeshProUGUI wallPrizetag;

    public int balloonAmount;

    void Start()
    {
        balloonPrizetag.text = balloonCost.ToString();
        minePrizetag.text = mineCost.ToString();
        wallPrizetag.text = wallCost.ToString();
        UpdateBalloonCount();
    }

    public void BuyBalloon()
    {
        if (GameManager.Coins >= balloonCost)
        {
            GameManager.ChangeCoinAmount(-balloonCost);
            balloonAmount++;
            UpdateBalloonCount();
        }
        
    }

    public void BuyMine()
    {
        if (GameManager.Coins >= mineCost)
        {
            GameManager.ChangeCoinAmount(-mineCost);
        }
    }

    public void BuyWall()
    {
        if (GameManager.Coins >= balloonCost)
        {
            GameManager.ChangeCoinAmount(-wallCost);
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
