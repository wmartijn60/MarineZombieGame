using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int coins;
    public static int Coins { get { return instance.coins; } }
    private bool placingState;
    public static bool PlacingState { get { return instance.placingState; } set { instance.placingState = value; } }
    static GameManager instance;
    private UIManager uiManager;
    private WaveSystem waveSystem;
    private CountDown countDown;
    private ScoreManager scoreManager;
    private SceneSwitch sceneSwitch;

    void Awake() {
        coins = 0;
        instance = this;
        placingState = true;
        uiManager = FindObjectOfType<UIManager>();
        waveSystem = GetComponent<WaveSystem>();
        countDown = GetComponent<CountDown>();
        scoreManager = GetComponent<ScoreManager>();
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        countDown.startingCountDown += uiManager.CanvasSwitch;
        countDown.stoppingCountdown += uiManager.CanvasSwitch;
        countDown.stoppingCountdown += waveSystem.StartWave;
    }
    /// <summary>
    /// Change the total amount of coins
    /// </summary>
    /// <param name="change">positive is adding, negative is subtracting</param>
    public static void ChangeCoinAmount(int change) {
        
        instance.coins += change;
        instance.uiManager.UpdateUI();
    }


    public static void CheckWaveStatus() {
        if (instance.waveSystem.Humanoids.childCount-1 <= 0) {
            if (instance.waveSystem.MaxWave <= instance.waveSystem.WaveNumber + 1)
            {
                instance.sceneSwitch.SelectScene(2);
            }
            instance.countDown.StartCountDown(30);
        }
    }
}
