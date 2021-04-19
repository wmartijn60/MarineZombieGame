using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    private int scoreCount;
    private int highScoreCount;
    private int playerScore;

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
 

    void OnApplicationQuit()
    {
       
        
        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetInt("highScore", highScoreCount);
            PlayerPrefs.Save();
            Debug.Log(highScoreCount);
        }
        PlayerPrefs.SetInt("playerScore", scoreCount);
        PlayerPrefs.GetInt("highScore");
        PlayerPrefs.GetInt("playerScore");
        PlayerPrefs.Save();
        LeaderBoard.Record("tim", highScoreCount);
        Debug.Log("run");
    }
}
