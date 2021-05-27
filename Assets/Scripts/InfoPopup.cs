using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPopup : MonoBehaviour
{
    [SerializeField]private GameObject popup;
    [SerializeField]private TextMeshProUGUI itemName;
    [SerializeField]private TextMeshProUGUI itemDescription;

    void Start()
    {
        
    }

    public void PlaceItemName(string newName)
    {
        itemName.text = newName;
    }

    public void PlaceItemDescription(string newDescription)
    {
        itemDescription.text = newDescription;
    }

    public void SwitchPanel()
    {
        if (popup.activeSelf)
        {
            popup.SetActive(false);
        }
        else
        {
            popup.SetActive(true);
        }
    }
}
