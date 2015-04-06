/* Author: Brian Summers - summers.brian.cs@gmail.com
 * Student ID: 110656609
 * Date: 4/6/15
 * CMSC425 Spring 2015
 * Programming Assignment 2
 * 
	This is the controller for the robots. This class controls how the robots move, detects collisions between the robots
	and the player or other robots, and uses the GameScoreManager to update how many robots remain. All robots use this
	controller to control their movement and in order to achieve "independent" movement of the robots, this class uses a 
	coroutine to randomly change the direction of motion for each robot.
*/
using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {

	Animator animator; // animator for the robots
	static bool active; // whether or not the robots are active
	public GameObject robot; // the robot for this instance
	static float boardBoundary = 10.0f; //boundaries of the platform
	static bool gameOver; // whether or not the game is over
	float turn; // direction the robot will move (0 for left, 1 for right)

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		active = false; // robots start inactive
		gameOver = false;
		float temp = Random.Range (0.0f, 0.2f); // choose random starting direction
		if (temp < 0.1f)
			turn = 0.0f;
		else
			turn = 1.0f;
		StartCoroutine(randomDirection ()); //start the coroutine to randomly change the robot's direction every few seconds
	}

	void Update() {
		//if the game is still going, check the boundaries and destory if the robot is outside the boundary
		if (!gameOver) {
			if (robot.transform.position.x > boardBoundary || robot.transform.position.x < -1.0f * boardBoundary ||
				robot.transform.position.z > boardBoundary || robot.transform.position.z < -1.0f * boardBoundary) {
				Destroy (robot);
				GameScoreManager.decrementAlive(1);
			}
		}
	}

	void FixedUpdate () {
		//if the game is over, stop animating the robot
		if (gameOver) {
			animator.speed = 0;
		} else {
			//otherwise, continue animating the robot
			animator.SetBool ("robot_active", active);
			animator.SetFloat ("robot_turn", turn);
		}
	}

	/// <summary>
	/// Sets the robot to active.
	/// </summary>
	public static void setActive() {
		active = true;
	}

	/// <summary>
	/// Sets the robot to idle.
	/// </summary>
	public static void setIdle() {
		active = false;
	}

	/// <summary>
	/// Coroutine for changing the direction of the robot.
	/// </summary>
	/// <returns>The direction.</returns>
	IEnumerator randomDirection() {
		//while the game is stil going
		while (!gameOver) {
			//wait a few seconds before changing the direction (between 1 and 6 seconds)
			yield return new WaitForSeconds (Random.Range (1.0f, 6.0f));
			//randomly choose direction
			float temp = Random.Range (0.0f,1.0f);
			if (temp < 0.5f)
				turn = 0.0f;
			else
				turn = 1.0f;
		}
	}

	/// <summary>
	/// Detects collision with the robot.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col) {
		//if the robot collides with another robot, destroy this robot (the other robot will do the same) and decrement the number
		//of robots alive by 1 (the other robot will also decrement)
		if (col.GetComponent<Collider> ().tag == "Robot") {
			Destroy (robot);
			GameScoreManager.decrementAlive(1);
		}
	}

	/// <summary>
	/// Set the game as over.
	/// </summary>
	public static void GameOver() {
		gameOver = true;
	}

}
