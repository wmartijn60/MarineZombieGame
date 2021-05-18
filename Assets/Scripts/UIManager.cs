using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI WaveNumerText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI playerMaxHealthText;
    [SerializeField] private GameObject restPanel;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI() {
        coinsText.text = GameManager.Coins.ToString();
        float currentHealth = GameManager.PlayerHealth.MaxHealth - GameManager.PlayerHealth.Health;
        playerHealthText.text = currentHealth.ToString();
        playerMaxHealthText.text = GameManager.PlayerHealth.MaxHealth.ToString();
    }

    public void waveStart()
    {
        WaveNumerText.text = WaveSystem.WaveNumber.ToString();
    }

    // Name may need to get changed to a better one
    public void CanvasSwitch()
    {
        waveStart();
        restPanel.SetActive(!restPanel.activeSelf);
    }

    public void UpdateCountDownText(int currentSeconds)
    {
        countDownText.text = "Next wave in: " + currentSeconds + " seconds";
    }
}
