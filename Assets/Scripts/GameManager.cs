using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int coins;
    public static int Coins { get { return instance.coins; } }
    private bool placingState;
    public static bool PlacingState { get { return instance.placingState; } set { instance.placingState = value; } }
    private static GameManager instance;
    private UIManager uiManager;
    private WaveSystem waveSystem;
    private CountDown countDown;
    [SerializeField] private HealthSystem playerHealth;
    public static HealthSystem PlayerHealth { get { return instance.playerHealth; } }
    [SerializeField] private int maxPlayerHealthIncrease = 10;
    [SerializeField] private int playerHealAmount = 5;
    [SerializeField] private SceneSwitch sceneSwitcher;
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
        playerHealth.died += PlayerDied;
    }
    /// <summary>
    /// Change the total amount of coins
    /// </summary>
    /// <param name="change">positive is adding, negative is subtracting</param>
    public static void ChangeCoinAmount(int change) {
        
        instance.coins += change;
        instance.uiManager.UpdateUI();
    }


    public static void DamagePlayer() {
        PlayerHealth.StartCoroutine("TakeDamage", 1);
        instance.uiManager.UpdateUI();
    }

    private void PlayerDied() {
        sceneSwitcher.SwitchScene(2);
    }

    public static void CheckWaveStatus() {
        if (instance.waveSystem.Humanoids.childCount-1 <= 0) {
            if (instance.waveSystem.MaxWave <= instance.waveSystem.WaveNumber + 1)
            {
                instance.sceneSwitch.SelectScene(2);
            }
            instance.countDown.StartCountDown(30);
            instance.IncreasePlayerHealth();
        }
    }

    private void IncreasePlayerHealth() {
        PlayerHealth.MaxHealth += maxPlayerHealthIncrease;
        if (PlayerHealth.Health + playerHealAmount + maxPlayerHealthIncrease > PlayerHealth.MaxHealth) {
            PlayerHealth.Health = PlayerHealth.MaxHealth;
        } else {
            PlayerHealth.Health += playerHealAmount + maxPlayerHealthIncrease;
        }
        instance.uiManager.UpdateUI();
    }
}
