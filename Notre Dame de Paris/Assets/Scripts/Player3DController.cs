using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3DController : MonoBehaviour {

	public float speed;
	private float jumpForce;
	private float gravity;
	private Vector3 moveDir = Vector3.zero;
	public Timer timer;
	public DeathMenu deathMenu;
	public StartMenu startMenu;

	void Start() {
		speed = 30f;
		jumpForce = 12f;
		gravity = 30f;
	}

	void Update() {
		if (Time.timeSinceLevelLoad >= 6f) {
			startMenu.StopMenu ();
		}

		if (timer.getTime() >= 60f) {
			deathMenu.lost ();
		}

		CharacterController controller = gameObject.GetComponent<CharacterController> ();
		if (controller.isGrounded) {
			moveDir = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;

			if (Input.GetButtonDown ("Jump")) {
				moveDir.y = jumpForce;
			}
		}
		moveDir.y -= gravity * Time.deltaTime;
		controller.Move (moveDir * Time.deltaTime);
		if (transform.position.y <= 20f) {
			die ();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Goal") {
				deathMenu.win ();
		}
	}

	public void die() {
		deathMenu.dead ();
	}
}
