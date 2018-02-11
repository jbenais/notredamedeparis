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
	private CharacterController controller;
	private bool endGame = false;
	private Animator anim;
	private int keys;
	public Text nbKeys;
	public TipsController tips;


	void Start() {
		speed = 70f;
		jumpForce = 54f;
		gravity = 78f;
		controller = gameObject.GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
		keys = 0;
		nbKeys.text = "0 / 3";
		StartCoroutine (popUpMessage ("You have 3 minutes to save Esmeralda !"));
	}

	void Update() {
		timer.gameObject.SetActive (!endGame);
		nbKeys.text = keys + " / " + "3";
		if (timer.getTime() <= 0f) {
			endGame = true;
			deathMenu.lost ();
		}
		if (!endGame) {
			if (controller.isGrounded) {
				moveDir = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
				anim.SetFloat ("Speed", Input.GetAxis ("Horizontal") + Input.GetAxis ("Vertical"));
				moveDir = transform.TransformDirection (moveDir);
				moveDir *= speed;
				if (Input.GetButtonDown ("Jump")) {
					moveDir.y = jumpForce;
				}
			}
			if (transform.position.y <= -300) {
				die ();
			}
			moveDir.y -= gravity * Time.deltaTime;
			controller.Move (moveDir * Time.deltaTime);
			transform.Rotate (0.0f, Input.GetAxis ("Mouse X") * 5f, 0.0f);
		}
	}
		
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Door") {
			if (keys < 3) {
				StartCoroutine (popUpMessage("You have to find every keys to open the door"));
			} else {
				other.gameObject.GetComponent<Animator> ().SetBool ("isOpen", true);
			}
		}
		if (other.gameObject.tag == "Goal" && keys == 3) {
			gameObject.GetComponent<CharacterController> ().enabled = false;
			gameObject.GetComponent<Animator> ().enabled = false;
			endGame = true;
			deathMenu.win ();
		} 
		else if (other.gameObject.tag == "Key") {
			keys++;
			other.gameObject.SetActive (false);
		}
		else if (other.gameObject.tag == "Ladder") {
			moveDir.y = jumpForce;
		}
	}

	public int getKeys() {
		return keys;
	}

	private IEnumerator popUpMessage(string message) {
		tips.tipsText.text = message;
		tips.gameObject.SetActive (true);
		yield return new WaitForSeconds(6f);
		tips.gameObject.SetActive (false);
	}

	public void die() {
		endGame = true;
		deathMenu.dead ();
	}
}
