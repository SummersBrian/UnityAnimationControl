/* Author: Brian Summers - summers.brian.cs@gmail.com
 * Student ID: 110656609
 * Date: 4/6/15
 * CMSC425 Spring 2015
 * Programming Assignment 2
 * 
	This is the controller for the player class. It controls how the player moves, uses the GameScoreManager to update
	scores when the player collides with robots, and determines if the player has fallen off the platform. When the 
	game is over, this class uses the EndGameTextManager to display whether or not the player has won the game, stops
	the movement of the player and the robots, and then waits for keyboard input from the user to retart the level,
	or quit the game.
*/
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	static Animator animator; //animator component
	public float vert; //vertical movement
	public float horiz; //horizontal movement
	public float sprint; //player sprinting
	public static bool gameOver; //is the game over

	/// <summary>
	/// Starts and initializes the instance.
	/// </summary>
	void Start () {
		animator = GetComponent<Animator>();
		vert = 0.0f;
		horiz = 0.0f;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			//get the up,left,right arrow keys or w,a,d keys
			vert = Input.GetAxis ("Vertical");
			horiz = Input.GetAxis ("Horizontal");
			//if the player is moving make the robots active
			if (vert > 0.0f) {
				RobotController.setActive ();
			} else { //otherwise make them inactive
				RobotController.setIdle ();
			}
			//check if the player moves off the platform
			if (transform.position.x > 10 || transform.position.x < -10 || transform.position.z > 10 || transform.position.z < -10) {
				gameOver = true;
				EndGameTextManager.setTextGameLost();
			}
			//controls sprinting movement
			Sprinting ();
		}
	}

	void FixedUpdate() {
		//if the game is over stop animation of the player
		if (gameOver) {
			animator.speed = 0;
		} else {
			//otherwise animate the player
			animator.SetFloat ("player_walk", vert);
			animator.SetFloat ("player_turn", horiz);
			animator.SetFloat ("player_sprint", sprint);
		}
		
	}

	/// <summary>
	/// Controls the sprinting of the character by checking if the left mouse button is held
	/// </summary>
	void Sprinting() {
		if (Input.GetButton ("Fire1"))
			sprint = 1.0f;
		else 
			sprint = 0.0f;
	}

	/// <summary>
	/// Collision is detected. We don't care about collisions with the platform, only the robots
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col) {
		if (col.GetComponent<Collider> ().tag != "Platform") {
			//only object we care about colliding with is a robot, in which case destroy the robot and increment the score,
			//and decrement the number of robots alive
			Destroy (col.gameObject);
			GameScoreManager.decrementAlive(1);
			GameScoreManager.incrementScore();
		}
	}

	/// <summary>
	/// The game is over
	/// </summary>
	public static void GameOver() {
		gameOver = true;
	}
}
