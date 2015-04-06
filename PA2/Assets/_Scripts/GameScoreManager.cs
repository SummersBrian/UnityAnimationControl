/* Author: Brian Summers - summers.brian.cs@gmail.com
 * Student ID: 110656609
 * Date: 4/6/15
 * CMSC425 Spring 2015
 * Programming Assignment 2
 * 
	This class is the manager for the game score. This class keeps track of the score, and how many robots remain alive.
	The only winning scenario is when the player kills (collides with) enough robots to reach the goal. The player will
	lose (and the game is over) when: (1) enough robots die such that the player can no longer reach the goal; (2) if
	the player falls off the platform.
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScoreManager : MonoBehaviour {
	
	public static int score; // number of robots killed
	public static int goal; // number of robot kills needed to win
	public static int alive; // remaining number of robots
	
	Text text; //game score to be updated
	
	// Use this for initialization
	void Start () {
		alive = 12;
		goal = 4;
		score = 0;
		text = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Robots Alive: " + alive + "\n" 
			+ "Killed: " + score + "/" + goal + "\n";

		// if all the robots die or enough robots die that the player can no longer reach the goal
		if (alive < 1 || (score + alive) < goal) {
			EndGameTextManager.setTextGameLost ();
			PlayerController.GameOver();
			RobotController.GameOver();
		} else if (score >= goal) { //if the player reaches the goal
			EndGameTextManager.setTextGameWon ();
			PlayerController.GameOver();
			RobotController.GameOver();
		}
	}
	
	/// <summary>
	/// Increments the score.
	/// </summary>
	public static void incrementScore() {
		score++;
	}
	
	/// <summary>
	/// Gets the score.
	/// </summary>
	/// <returns>The score.</returns>
	public static int getScore() {
		return score;
	}

	/// <summary>
	/// Decrements the number of robots alive by <param name="num">>.
	/// </summary>
	/// <param name="num">Number.</param>
	public static void decrementAlive(int num) {
		alive -= num;
	}
}
