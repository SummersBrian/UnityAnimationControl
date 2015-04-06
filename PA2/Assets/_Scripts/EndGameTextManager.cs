/* Author: Brian Summers - summers.brian.cs@gmail.com
 * Student ID: 110656609
 * Date: 4/6/15
 * CMSC425 Spring 2015
 * Programming Assignment 2
 * 
	This class is the manager for the end of game text. The  end game text appears when the game end and prompts the player
	to retart or quit the game. The text displayed depends on whether the player has won or lost the game.
*/
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndGameTextManager : MonoBehaviour {
	
	Text gameOverText; // text item
	private static string gameStatus; // winning or losing text
	static bool gameOver; // whether or not the game has ended
	
	// Use this for initialization
	void Start () {
		gameOverText = GetComponent<Text> ();
		gameStatus = "";
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if the game is over, get user input
		if (gameOver) {
			if (Input.GetKeyDown(KeyCode.R))
				Application.LoadLevel(0);
			else if (Input.GetKeyDown(KeyCode.Q))
				Application.Quit();
		}
		gameOverText.text = gameStatus;
	}
	
	/// <summary>
	/// Sets the end game text to the winning status.
	/// </summary>
	public static void setTextGameWon() {
		gameStatus = "YOU WIN!\nPress 'r' to replay or 'q' to quit";
		gameOver = true;
	}
	
	/// <summary>
	/// Sets the end game text to losing status.
	/// </summary>
	public static void setTextGameLost() {
		gameStatus = "You Lose =[\nPress 'r' to replay or 'q' to quit";
		gameOver = true;
	}
}
