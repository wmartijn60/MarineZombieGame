using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int coins;
    public static int Coins { get { return coins; } }
    static GameManager instance;
    private static UIManager uiManager;
    private static WaveSystem waveSystem;
    private static CountDown countDown;

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

    public static void CheckWaveStatus() {
        if (waveSystem.Humanoids.childCount-1 <= 0) {
            countDown.StartCountDown(30);
        }
    }
}
