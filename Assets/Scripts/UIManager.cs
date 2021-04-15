using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI() {
        coinsText.text = GameManager.Coins.ToString();
    }
}
