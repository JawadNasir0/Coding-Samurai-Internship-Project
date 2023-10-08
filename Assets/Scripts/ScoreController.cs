using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text scoreText;
	int score=0;
	public TMP_Text livesText;
	int lives=3;
	public TMP_Text highScoreText;
	int highScore = 0;
	Renderer basketrender; 
	public GameObject restartCanvas;
	public GameObject spawner;
    void Start()
    {
        basketrender = GetComponent<Renderer>();
		highScore = PlayerPrefs.GetInt("HighScore", 0); 
		highScoreText.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
		livesText.text = lives.ToString();
		if (score > highScore)
		{
			highScore = score; 
			PlayerPrefs.SetInt("HighScore", highScore); 
			highScoreText.text = highScore.ToString();
		}
		
    }
	
	void OnTriggerEnter2D(Collider2D target)
	{
		if(lives==3||lives==2)
		{
			if(target.tag == "Bomb")
			{
				lives--;
				Destroy(target.gameObject);
			}
		}
		else if(lives==1)
		{
			if(target.tag == "Bomb")
			{
				lives=0;
				Destroy(target.gameObject);
				basketrender.enabled=false;
				StartCoroutine(WaitTilRestart());

			}
		}
	}
	void OnTriggerExit2D(Collider2D target)
	{
		
		if(target.tag == "Fruit")
		{
			Destroy(target.gameObject);
			score=score+10;
		}
	}
	IEnumerator WaitTilRestart()
	{
		yield return new WaitForSeconds(1.3f);
		spawner.SetActive(false);
		restartCanvas.SetActive(true);
	}
	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
