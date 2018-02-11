using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	public int playerHealth = 3;
	public float restartDelay = 2;
	public Text gameoverText;
	public static int score;

	void Start() 
	{
		playerHealth = 3;
		EnemyDeath.score = 0;
	}
		
	//Reduces health on hit
	void OnTriggerEnter (Collider other){
		
		if (other.gameObject.CompareTag ("Enemy")) {
			playerHealth -= 1;
		}

		//Will load scene with a delay
		if (playerHealth <= 0) {
			SetGameOverText ();
			Invoke ("restartLevel", restartDelay);
		}
	}

	void SetGameOverText () {
		gameoverText.text = "Game Over";
	}

	void restartLevel () {
		SceneManager.LoadScene (0);
	}
}