using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int coins;
    public static int Coins { get { return coins; } }
    static GameManager instance;
    private static UIManager uiManager;
    void Awake() {
        instance = this;
        uiManager = FindObjectOfType<UIManager>();
    }
    /// <summary>
    /// Change the total amount of coins
    /// </summary>
    /// <param name="change">positive is adding, negative is subtracting</param>
    public static void ChangeCoinAmount(int change) {
        coins += change;
        uiManager.UpdateUI();
    }
}
