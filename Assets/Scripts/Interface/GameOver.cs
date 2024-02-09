using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_InputField usernameInput;

    private void Start()
    {
        scoreText.text = "Score: " + ((int)GameManager.Instance.score).ToString();
    }

    public void SubmitScore()
    {
        if (usernameInput.text == "") return;

        GameManager.AddHighscore(usernameInput.text, (int)GameManager.Instance.score);

        SceneManager.LoadScene("Menu");
    }
}
