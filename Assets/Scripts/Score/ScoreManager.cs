using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private TextMeshProUGUI scoreUI;
    private int playerScore;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
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