using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInterface : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Update()
    {
        scoreText.text = "Score: " + Mathf.Floor(GameManager.Instance.score).ToString();
    }
}
