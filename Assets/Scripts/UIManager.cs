﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI WaveNumerText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI playerMaxHealthText;
    [SerializeField] private TextMeshProUGUI survivorSurvivedText;
    [SerializeField] private TextMeshProUGUI maxSurvivorSurvivedText;
    [SerializeField] private GameObject shopUIPanel;
    [SerializeField] private GameObject gameUIPanel;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI() {
        coinsText.text = GameManager.Coins.ToString();
        float currentHealth = GameManager.PlayerHealth.MaxHealth - GameManager.PlayerHealth.Health;
        playerHealthText.text = currentHealth.ToString();
        playerMaxHealthText.text = GameManager.PlayerHealth.MaxHealth.ToString();
        survivorSurvivedText.text = GameManager.WaveSystem.SurvivorAmount.ToString();
        maxSurvivorSurvivedText.text = GameManager.WaveSystem.MaxSurvivorAmount.ToString();
    }

    public void WaveStart()
    {
        WaveNumerText.text = WaveSystem.instance.WaveNumber.ToString();
    }

    // Name may need to get changed to a better one
    public void ShowGameUIPanel() {
        shopUIPanel.SetActive(false);
        gameUIPanel.SetActive(true);
    }

    public void ShowShopPanel() {
        shopUIPanel.SetActive(true);
        gameUIPanel.SetActive(false);
    }

    public void UpdateCountDownText(int currentSeconds)
    {
        countDownText.text = "Next wave in: " + currentSeconds + " seconds";
    }
}
