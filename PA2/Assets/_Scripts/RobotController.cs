using UnityEngine;
using System.Collections;

public class RobotController : MonoBehaviour {

	Animator animator;
	public GameObject robotRootObject;
	static bool active;

	float turn;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		active = false;
		turn = 0.0f;
	}

	void Update() {
	}

	void FixedUpdate () {
		animator.SetBool ("robot_active", active);
	}

	public static void setActive() {
		active = true;
	}

}
