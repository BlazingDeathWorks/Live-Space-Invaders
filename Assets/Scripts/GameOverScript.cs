using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
	public GameObject GameOverCanvas;
	public GameObject[] MiscItems;
	[SerializeField] private Text HighScoreText;

	public void GameOver()
	{
		foreach(GameObject m in MiscItems)
		{
			m.SetActive(false);
		}
		foreach(EnemyScript enemy in FindObjectsOfType<EnemyScript>())
		{
			Destroy(enemy.gameObject);
		}
		GameOverCanvas.SetActive(true);
		
		HighScoreText.text = "HIGH SCORE: " + PlayerScore.highScore.ToString().PadLeft(10, '0').Substring(0, 10);
	}
	
	public void Retry()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void Quit()
	{
		Debug.Log("Quitting...");
		Application.Quit();
	}
}
