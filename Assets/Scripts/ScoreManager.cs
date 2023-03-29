using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
	[SerializeField] private Text scoreText;
    [SerializeField] private int pointsPerKill = 5;
	private int score;

    private void Awake()
    {
        Instance = this;
    }

    //Tooling
    [ContextMenu("ResetHighScore")]
    private void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void AddScore()
    {
        score += pointsPerKill;
        scoreText.text = score.ToString().PadLeft(10, '0').Substring(0, 10);
    }

    public int GetHighScore()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (score <= highScore) return highScore;

        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
        return highScore;
    }
}
