using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour {

	public int Health = 2;
	public float DelayDeath;

	void start() 
	{
		Health = 2;
	}

	//Reduces health on hit
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("Player Projectile")) 
		{
			Health -= 1;
		}

		//Destroys enemy with an optional delay
		if (Health <= 0) 
		{
			Destroy (gameObject, DelayDeath);
		}
	}
}