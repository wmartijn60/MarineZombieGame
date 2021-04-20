using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    private int scoreCount;
    private int highScoreCount;

    private string playerName;

    public TMP_InputField nameInputField;

    // Update is called once per frame
    void Update()
    {
        scoreCount = GameManager.Coins;

        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetInt("highScore", highScoreCount);
        }


    }

    public void EnterName()
    {
        playerName = nameInputField.text;
        sendPlayerScore();
    }


     void sendPlayerScore()
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
