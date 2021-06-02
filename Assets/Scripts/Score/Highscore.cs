using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Highscore : MonoBehaviour
{
    private int scoreCount;
    private int highScoreCount;

    private string playerName;

    [SerializeField] private TMP_InputField nameInputField;

    void Start()
    {
        scoreCount = PlayerPrefs.GetInt("Score"); ;

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetInt("highScore", highScoreCount);
        }
    }

    public void EnterName()
    {
        playerName = nameInputField.text;
        SendPlayerScore();
    }

    public void DisableButton(Button b)
    {
        b.image.color = b.colors.disabledColor;
        b.enabled = false;
    }

    private void SendPlayerScore()
    {
        LeaderBoard.Record(playerName, highScoreCount);
    }

    void OnApplicationQuit()
    {
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetInt("highScore", highScoreCount);
            PlayerPrefs.Save();
        }

        PlayerPrefs.GetInt("highScore");
        PlayerPrefs.Save();
    }
}
