using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{   
    [SerializeField]private int balloonCost;
    [SerializeField]private int mineCost;
    [SerializeField]private int wallCost;

    [SerializeField] private TextMeshProUGUI balloonPrizetag;
    [SerializeField] private TextMeshProUGUI minePrizetag;
    [SerializeField] private TextMeshProUGUI wallPrizetag;

    public int BalloonAmount;

    void Start()
    {
        balloonPrizetag.text = balloonCost.ToString();
        minePrizetag.text = mineCost.ToString();
        wallPrizetag.text = wallCost.ToString();
    }

    public void BuyBalloon()
    {
        if (GameManager.Coins >= balloonCost)
        {
            GameManager.ChangeCoinAmount(-balloonCost);
            BalloonAmount++;
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

    public void UseBalloon()
    {

    }

}
