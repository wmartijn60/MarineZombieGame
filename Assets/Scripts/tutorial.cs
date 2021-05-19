using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorialImageObject;
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private TextMeshProUGUI tutorialNumber;
    private int currentText = 0;
    
    public List<string> TutorialTextlist = new List<string>();
    public List<Sprite> TutorialImagelist = new List<Sprite>();

    // starts the script with first card at the ready
    void Start()
    {
        displayText();
        displayNumber(currentText);
        displayImage();
    }

    //go to the next/ previus tutorial card
    public void updateTextForward()
    {
        if (currentText == TutorialTextlist.Count - 1)
        {
            currentText = 0;
        }
        else
        {
            currentText += 1;
        }
        displayText();
        displayNumber(currentText);
        displayImage();
    }

    public void updateTextBackward()
    {
        if (currentText == 0)
        {
            currentText = TutorialTextlist.Count - 1;
        }
        else
        {
            currentText -= 1;
        }
        displayText();
        displayNumber(currentText);
        displayImage();
    }


    //open / close the tutorial
    public void tutorialOpen()
    {
        this.gameObject.SetActive(true);
    }

    public void tutorialClose()
    {
        this.gameObject.SetActive(false);
    }


    //displays the verius types of content
    public void displayText()
    {
        tutorialText.text = TutorialTextlist[currentText];
    }
    public void displayNumber(int current)
    {
        tutorialNumber.text = (current += 1)+ ".";
    }
    public void displayImage()
    {
        tutorialImageObject.GetComponent<Image>().sprite = TutorialImagelist[currentText];
    }
}
