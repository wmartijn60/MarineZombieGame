using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinsText;

    public void UpdateUI() {
        coinsText.text = GameManager.Coins.ToString();
    }
}
