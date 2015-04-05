using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Animator animator; //animator component
	public float vert; //vertical movement
	public float horiz; //horizontal movement
	public float sprint;

	private bool gameOver;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		vert = 0.0f;
		horiz = 0.0f;
		gameOver = false;

	}
	
	// Update is called once per frame
	void Update () {
		vert = Input.GetAxis ("Vertical");
		horiz = Input.GetAxis ("Horizontal");
		Sprinting ();
	}

	void FixedUpdate() {
		if (gameOver) {
			Application.Quit ();
		}
		animator.SetFloat ("player_walk", vert);
		animator.SetFloat ("player_turn", horiz);
		animator.SetFloat ("player_sprint", sprint);

		if (transform.position.x > 10 || transform.position.x < -10 || transform.position.z > 10 || transform.position.z < -10)
			gameOver = true;


	}

	void Sprinting() {
		if (Input.GetButton ("Fire1"))
			sprint = 1.0f;
		else 
			sprint = 0.0f;
	}
}
