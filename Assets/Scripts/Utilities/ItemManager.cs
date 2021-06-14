using UnityEngine;
using TMPro;

public class ItemManager : MonoBehaviour
{   
    public static ItemManager instance;

    [SerializeField]private int startCoins = 100;
    [SerializeField]private int balloonCost;
    [SerializeField] private int teleporterCost;
    [SerializeField]private int mineCost;
    [SerializeField]private int wallCost;

    [SerializeField] private TextMeshProUGUI balloonsTotal;
    [SerializeField] private TextMeshProUGUI teleporterTotal;
    [SerializeField] private TextMeshProUGUI balloonPrizetag;
    [SerializeField] private TextMeshProUGUI minePrizetag;
    [SerializeField] private TextMeshProUGUI wallPrizetag;

    [SerializeField] private bool debugCoins;

    private FmodPlayer fmodPlayer;

    public int balloonAmount;
    public int teleporterAmount;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

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

    public void teleporter()
    {
        if (GameManager.Coins >= teleporterCost)
        {
            GameManager.ChangeCoinAmount(-teleporterCost);
            fmodPlayer.PlaySound("event:/Purchase");
            teleporterAmount++;
            UpdateteleporterCount();
        }
        else
            fmodPlayer.PlaySound("event:/NotEnoughMoney");
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

    public void BuyMine()
    {
        if (GameManager.Coins >= mineCost)
        {
            GameManager.ChangeCoinAmount(-mineCost);
            fmodPlayer.PlaySound("event:/Purchase");
        }
        else
            fmodPlayer.PlaySound("event:/NotEnoughMoney");
    }

    public void BuyWall()
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

    public void UpdateteleporterCount()
    {
        teleporterTotal.text = teleporterAmount.ToString();
    }
}
