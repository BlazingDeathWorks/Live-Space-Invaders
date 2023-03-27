using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{   
	[SerializeField] private Text scoreText;
	public static int score;
	public static int highScore;
	
    void Start()
    {
		score = 0;
		highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    void Update()
    {
		scoreText.text = score.ToString().PadLeft(10, '0').Substring(0, 10);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }
}
