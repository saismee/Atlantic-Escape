using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float score;

    private void Start()
    {
        if (Instance != null)
        {
            throw new Exception("There cannot be more than one GameManager");
        }
        Instance = this;
    }
}
