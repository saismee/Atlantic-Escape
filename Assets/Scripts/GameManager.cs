using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float score;
    public float difficulty = 1f;

    private void Start()
    {
        if (Instance != null)
        {
            throw new Exception("There cannot be more than one GameManager");
        }
        Instance = this;
    }

    private void Update()
    {
        difficulty += Time.deltaTime / 100f;
    }
}
