using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Tooltip("Array of leaderboard text objects")]
    [SerializeField] private TMP_Text[] scoreTexts;

    // this is a bad way of doing this but its quick
    private void Start()
    {
        for (int i = 1; i < GameManager.Instance.leaderboard.Length; i++)
        {
            // starting from 1 is important so we skip the lowest score!!

            LeaderboardEntry entry = GameManager.Instance.leaderboard[i];

            if (entry.user == null || entry.score == 0)
            {
                scoreTexts[i - 1].text = ""; // hide any missing/blank entries
                continue;
            }
            scoreTexts[i - 1].text = entry.user + ": " + entry.score.ToString() + " Score";
        }
    }

    private void Update()
    {
        if (Input.anyKeyDown) GameManager.StartGame();
    }
}
