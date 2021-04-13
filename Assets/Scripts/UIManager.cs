using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;
    [SerializeField] private GameObject restPanel;
    [SerializeField] private Text countDownText;

    public void UpdateUI() {
        coinsText.text = GameManager.Coins + " coins";
    }

    // Name may need to get changed to a better one
    public void CanvasSwitch() {
        restPanel.SetActive(!restPanel.activeSelf);
    }

    public void UpdateCountDownText(int currentSeconds) {
        countDownText.text = "Next wave in: " + currentSeconds + " seconds";
    }
}
