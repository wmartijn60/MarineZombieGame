using UnityEngine;

public class LeaderboardTestGUI : MonoBehaviour
{
    private string _nameInput = "";
    private string _scoreInput = "0";

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

        // Display high scores!
        for (int i = 0; i < LeaderBoard.EntryCount; ++i)
        {
            var entry = LeaderBoard.GetEntry(i);
            GUILayout.Label("Name: " + entry.name + ", Score: " + entry.score);
        }

        // Interface for reporting test scores.
        GUILayout.Space(10);

        _nameInput = GUILayout.TextField(_nameInput);
        _scoreInput = GUILayout.TextField(_scoreInput);

        GUILayout.EndArea();
    }
}