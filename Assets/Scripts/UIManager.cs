using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private GameObject restPanel;    

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI() {
        coinsText.text = GameManager.Coins.ToString();
    }

    // Name may need to get changed to a better one
    public void CanvasSwitch()
    {
        restPanel.SetActive(!restPanel.activeSelf);
    }

    public void UpdateCountDownText(int currentSeconds)
    {
        countDownText.text = "Next wave in: " + currentSeconds + " seconds";
    }
}
