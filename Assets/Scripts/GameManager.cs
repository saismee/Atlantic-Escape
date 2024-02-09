using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public struct LeaderboardEntry : IComparable
{
    public string user;
    public int score;

    public int CompareTo(object obj)
    {
        return score.CompareTo( ( (LeaderboardEntry)obj ).score );
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float score;
    public float difficulty = 1f;

    public bool gameActive;

    public LeaderboardEntry[] leaderboard;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;

        LoadLeaderboard();
    }

    private void Update()
    {
        if (!Instance.gameActive) return;
        difficulty += Time.deltaTime / 100f;
        score += Time.deltaTime * 100f;
    }

    public static void StartGame()
    {
        Instance.score = 0f;
        Instance.difficulty = 1f;
        SceneManager.LoadScene("Game");
        Instance.gameActive = true;
    }

    public static void GameOver()
    {
        Instance.gameActive = false;
        SceneManager.LoadScene("GameOver");
    }

    public static void SaveLeaderboard()
    {
        string data = JsonHelper.ToJson(Instance.leaderboard);
        //Debug.Log(data);
        PlayerPrefs.SetString("ScoreLeaderboard", data);
    }
    public static void LoadLeaderboard()
    {
        string data = PlayerPrefs.GetString("ScoreLeaderboard", "");
        if (data != "")
        {
            LeaderboardEntry[] newLeaderboard = JsonHelper.FromJson<LeaderboardEntry>(data); // this is dumb
            Instance.leaderboard = newLeaderboard;
            return;
        }

        Instance.leaderboard = new LeaderboardEntry[6]; // 5 values, plus an extra for sorting
        for (int i = 0; i < 6; i++)
        {
            Instance.leaderboard[i] = new LeaderboardEntry() { score = 0, user = null };
        }
        Array.Sort(Instance.leaderboard);
    }

    public static void AddHighscore(string user, int newScore)
    {
        Instance.leaderboard[0] = new LeaderboardEntry() { score = newScore, user = user };
        // we set the first value of the array to our new entry

        Array.Sort(Instance.leaderboard);
        // sorts ascending, the highest in the array is top score!

        SaveLeaderboard();
    }
}
