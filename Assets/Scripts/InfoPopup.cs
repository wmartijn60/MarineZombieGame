using UnityEngine;
using TMPro;

public class InfoPopup : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject upgrades;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private Animator infoAnim;
    [SerializeField] private CountDown countDown;

    public void PlaceItemName(string newName)
    {
        itemName.text = newName;
    }

    public void PlaceItemDescription(string newDescription)
    {
        itemDescription.text = newDescription;
    }

    public void PlayAnim(string animName)
    {
        if (!infoAnim.gameObject.activeSelf)
        {
            infoAnim.gameObject.SetActive(true);
        }
        if (upgrades.activeSelf)
        {
            upgrades.SetActive(false);
        }
        infoAnim.SetTrigger(animName);
    }

    public void ShowUpgrades()
    {
        if (infoAnim.gameObject.activeSelf)
        {
            infoAnim.gameObject.SetActive(false);
        }
        if (!upgrades.activeSelf)
        {
            upgrades.SetActive(true);
        }

    }

    public void SwitchPanel()
    {
        if (popup.activeSelf)
        {
            popup.SetActive(false);
            countDown.ContinueCountDown();
        }
        else
        {
            popup.SetActive(true);            
            countDown.PauseCountDown();
        }
    }
}
