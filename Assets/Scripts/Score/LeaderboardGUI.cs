using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LeaderboardGUI : MonoBehaviour
{
    private string _nameInput = "";
    private string _scoreInput = "0";

    public List<TextMeshProUGUI> leaderBoard;
    
    
    private void OnGUI()
    {


        // Display high scores!
        for (int i = 0; i < LeaderBoard.EntryCount; ++i)
        {
            var entry = LeaderBoard.GetEntry(i);
            leaderBoard[i].text = entry.name + " : " + entry.score;
            

        }

    }
}