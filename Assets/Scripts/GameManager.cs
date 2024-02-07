using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float score;
    public float difficulty = 1f;

    public bool gameActive;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    private void Update()
    {
        difficulty += Time.deltaTime / 100f;
    }

    public static void Start()
    {
        Instance.score = 0f;
        Instance.difficulty = 1f;
        SceneManager.LoadScene("Game");
        Instance.gameActive = true;
    }

    public static void GameOver()
    {
        Instance.gameActive = false;
        SceneManager.LoadScene("Menu");
    }
}
