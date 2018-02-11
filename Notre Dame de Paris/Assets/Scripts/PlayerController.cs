using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public bool firstAxis = true;
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private Animator anim;
	private CharacterController controller;

	void Start()
	{
		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController>();
	}

	void Update()
	{
		MovePlayer();
	}

	void MovePlayer()
	{
		var z = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", z);
		if (z > 0)
			transform.rotation = Quaternion.Euler(new Vector3(0, firstAxis ? 90 : 0, 0));
		else if (z < 0)
			transform.rotation = Quaternion.Euler(new Vector3(0, firstAxis ? -90 : 180, 0));

		if (controller.isGrounded) {
			moveDirection = new Vector3 (0, 0, Mathf.Abs(z));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump") || Input.GetKeyDown(KeyCode.UpArrow))
				moveDirection.y = jumpSpeed;
		} 
		else {
			if (firstAxis) {
				moveDirection.x += z * Time.deltaTime * 30;
				moveDirection.x = moveDirection.x > speed ? speed : moveDirection.x;
				moveDirection.x = moveDirection.x < 0 - speed ? 0 - speed : moveDirection.x;
			} else {

				moveDirection.z += z * Time.deltaTime * 30;
				moveDirection.z = moveDirection.z > speed ? speed : moveDirection.z;
				moveDirection.z = moveDirection.z < 0 - speed ? 0 - speed : moveDirection.z;
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}