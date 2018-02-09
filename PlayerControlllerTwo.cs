using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlllerTwo : MonoBehaviour {

	private bool walking;
	private bool walkLeft;
	private bool walkRight;
	private bool climbing;
	private bool climbUp;
	private bool climbDown;
	private bool jumping;

	public Vector2 velocity;
	public state curState;
	public enum state {
		Grounded,
		Jumping,
		Climbing,
		Dead
	}


	void Update () {
		PlayerInput ();
		PlayerPosition ();
		PlayerState ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Ground") {
			curState = state.Grounded;
		}

		if (other.gameObject.tag == "Ladder") {
			curState = state.Climbing;
		} 
		else {
			curState = state.Jumping;
		}
	}

	void PlayerState (){
		if (curState == state.Grounded) {
			climbing = false;
			climbUp = false;
			climbDown = false;
			walking = true;
			walkLeft = true;
			walkRight = true;
		}

		if (curState == state.Climbing) {
			walking = false;
			walkLeft = false;
			walkRight = false;
			climbing = true;
			climbUp = true;
			climbDown = true;
		}

		if (curState == state.Jumping) {
			climbing = false;
			climbUp = false;
			climbDown = false;
		}
	}

	void PlayerPosition() {
		Vector3 pos = transform.localPosition;
		Vector3 scale = transform.localScale;

		if (walking) {
			if (walkLeft) {
				pos.x -= velocity.x * Time.deltaTime;
				scale.x = -4;
			}

			if (walkRight) {
				pos.x += velocity.x * Time.deltaTime;
				scale.x = 4;
			}
		}

		if (climbing) {
			if (climbUp) {
				pos.y += velocity.y * Time.deltaTime;
			}
			if (climbDown) {
				pos.y -= velocity.y * Time.deltaTime;
			}
		}

		transform.localPosition = pos;
		transform.localScale = scale;
	}

	void PlayerInput () {
		bool Left = Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow);
		bool Right = Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow);
		bool Up = Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow);
		bool Down = Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow);
		bool jump = Input.GetKeyDown (KeyCode.Z);

		walking = walkLeft || walkRight;
		walkLeft = Left && !Right;
		walkRight = Right && !Left;

		jumping = jump;

		climbing = climbUp || climbDown;
		climbUp = Up && !Down;
		climbDown = Down && !Up;
	}
}
