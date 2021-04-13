using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int coins;
    public static int Coins { get { return coins; } }
    static GameManager instance;
    private static UIManager uiManager;
    private WaveSystem waveSystem;
    private CountDown countDown;

    void Awake() {
        instance = this;
        uiManager = FindObjectOfType<UIManager>();
        waveSystem = GetComponent<WaveSystem>();
        countDown = GetComponent<CountDown>();
        countDown.startingCountDown += uiManager.CanvasSwitch;
        countDown.stoppingCountdown += uiManager.CanvasSwitch;
        countDown.stoppingCountdown += waveSystem.StartWave;
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
