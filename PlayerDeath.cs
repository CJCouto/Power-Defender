using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {

	public int playerHealth = 1;
	public float restartDelay = 2;

	void start() 
	{
		playerHealth = 1;
	}

	//Reduces health on hit
	void OnTriggerEnter (Collider other){
		
		if (other.gameObject.CompareTag ("Enemy")) {
			playerHealth -= 1;
		}

		//Will load scene with a delay
		if (playerHealth <= 0) {
			Invoke ("restartLevel", restartDelay);
		}
	}
		
	void restartLevel () {
		SceneManager.LoadScene ("scenename");
	}
}