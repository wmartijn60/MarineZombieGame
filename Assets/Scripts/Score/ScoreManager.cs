using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int playerScore;
    [SerializeField]private TextMeshProUGUI scoreUI;

    void Awake()
    {
        if (ScoreManager.Instance == null)
            ScoreManager.Instance = this;
        else
            Destroy(this.gameObject);
    }

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    public void AddScore(int newScore)
    {
        playerScore += newScore;
        PlayerPrefs.SetInt("Score", playerScore);
        scoreUI.text = "Score: " + playerScore;
    }
}