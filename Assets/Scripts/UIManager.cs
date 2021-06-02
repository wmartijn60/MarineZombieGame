using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [SerializeField] private TextMeshProUGUI waveChangeNumberText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI playerMaxHealthText;
    [SerializeField] private TextMeshProUGUI survivorSurvivedText;
    [SerializeField] private TextMeshProUGUI maxSurvivorSurvivedText;
    [SerializeField] private GameObject shopUIPanel;
    [SerializeField] private GameObject gameUIPanel;
    [SerializeField] private GameObject winScreenUI;
    [SerializeField] private GameObject loseScreenUI;
    [SerializeField] private Animator warningSignAnim;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinsText.text = GameManager.Coins.ToString();
        float currentHealth = GameManager.PlayerHealth.MaxHealth - GameManager.PlayerHealth.Health;
        playerHealthText.text = currentHealth.ToString();
        playerMaxHealthText.text = GameManager.PlayerHealth.MaxHealth.ToString();
        survivorSurvivedText.text = GameManager.WaveSystem.SurvivorAmount.ToString();
        maxSurvivorSurvivedText.text = GameManager.WaveSystem.MaxSurvivorAmount.ToString();
        CheckWarningUI();

    }

    public void WaveStart()
    {
        waveNumberText.text = WaveSystem.instance.WaveNumber.ToString();
        waveChangeNumberText.text = WaveSystem.instance.WaveNumber.ToString();
    }

    public void ShowGameUIPanel() 
    {
        shopUIPanel.SetActive(false);
        gameUIPanel.SetActive(true);
    }

    public void ShowShopPanel()
    {
        shopUIPanel.SetActive(true);
        gameUIPanel.SetActive(false);
    }

    public void UpdateCountDownText(int currentSeconds)
    {
        countDownText.text = "Next wave in: " + currentSeconds + " seconds";
    }

    private void CheckWarningUI()
    {
        if (GameManager.PlayerHealth.Health <= GameManager.PlayerHealth.MaxHealth / 2)
        {
            warningSignAnim.gameObject.SetActive(true);
            warningSignAnim.SetBool("IsInDanger", true);
        }
        else
        {
            warningSignAnim.SetBool("IsInDanger", false);
            warningSignAnim.gameObject.SetActive(false);
        }
    }

    public void WinGame()
    {
        winScreenUI.SetActive(true);
    }

    public void LoseGame()
    {
       loseScreenUI.SetActive(true);
    }
}
