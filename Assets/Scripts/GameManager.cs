using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private int maxPlayerHealthIncrease = 10;
    [SerializeField] private int playerHealAmount = 5;

    [SerializeField] private Animator coinAnim;

    private int coins;
    public static int Coins { get { return instance.coins; } }
    private bool placingState;
    public static bool PlacingState { get { return instance.placingState; } set { instance.placingState = value; } }
    private WaveSystem waveSystem;
    public static WaveSystem WaveSystem { get { return instance.waveSystem; } }
    [SerializeField] private HealthSystem playerHealth;
    public static HealthSystem PlayerHealth { get { return instance.playerHealth; } }
    private UIManager uiManager;
    private CountDown countDown;

    private SceneSwitch sceneSwitcher;

    void Awake()
    {
        coins = 0;
        instance = this;
        placingState = true;
        uiManager = FindObjectOfType<UIManager>();
        waveSystem = GetComponent<WaveSystem>();
        countDown = GetComponent<CountDown>();
        sceneSwitcher = FindObjectOfType<SceneSwitch>();
        countDown.startingCountDown += uiManager.ShowShopPanel;
        countDown.startingCountDown += uiManager.WaveStart;
        countDown.stoppingCountdown += uiManager.ShowGameUIPanel;
        countDown.stoppingCountdown += uiManager.WaveStart;
        countDown.stoppingCountdown += uiManager.UpdateUI;
        countDown.stoppingCountdown += waveSystem.StartWave;
        playerHealth.died += PlayerDied;

    }

    /// <summary>
    /// Change the total amount of coins
    /// </summary>
    /// <param name="change">positive is adding, negative is subtracting</param>
    public static void ChangeCoinAmount(int change)
    {
        instance.coins += change;
        instance.uiManager.UpdateUI();
    }

    public static void SurvivorSurvived()
    {
        instance.waveSystem.SurvivorAmount += 1;
        instance.uiManager.UpdateUI();
    }

    public static void DamagePlayer()
    {
        PlayerHealth.StartCoroutine("TakeDamage", 1);
        instance.uiManager.UpdateUI();
    }

    private void PlayerDied()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX One-Shots/Loser", instance.GetComponent<Transform>().position);
        instance.uiManager.LoseGame();
        sceneSwitcher.LoadSceneWithDelay(2,3f);
    }

    public static void CheckWaveStatus()
    {
        if (instance.waveSystem.Humanoids.childCount-1 <= 0) 
        {
            if (instance.waveSystem.MaxWave < instance.waveSystem.WaveNumber)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX One-Shots/Victory", instance.GetComponent<Transform>().position);
                instance.uiManager.WinGame();
                instance.countDown.PauseCountDown();
                instance.sceneSwitcher.LoadSceneWithDelay(2, 4f);
            }
            else
            {
                instance.countDown.StartCountDown(30);
                instance.IncreasePlayerHealth();
                ChangeCoinAmount(instance.waveSystem.BonusCoins);
                instance.coinAnim.SetTrigger("GetCoin");
            }

        }
    }

    private void IncreasePlayerHealth()
    {
        PlayerHealth.MaxHealth += maxPlayerHealthIncrease;
        if (PlayerHealth.Health + playerHealAmount + maxPlayerHealthIncrease > PlayerHealth.MaxHealth)
        {
            PlayerHealth.Health = PlayerHealth.MaxHealth;
        } 
        else
        {
            PlayerHealth.Health += playerHealAmount + maxPlayerHealthIncrease;
        }
        instance.uiManager.UpdateUI();
    }
}
