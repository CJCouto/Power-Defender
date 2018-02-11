using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour {

	public static int score;
	public int Health;
	public float DelayDeath;
	public Text ScoreText;


	void start() 
	{
		Health = 1;
		DelayDeath = 1;
	}

	//Reduces health on hit
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player Projectile")) 
		{
			Health -= 1;
		}

		//Destroys enemy & increments Score
		if (Health <= 0) 
		{
			score += 1;
			SetScoreText ();
			Destroy (gameObject, DelayDeath);
		}
	}

	void SetScoreText () {
		ScoreText.text = "Score: " + score;
	}

}