using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class LeaderboardGUI : MonoBehaviour
{
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