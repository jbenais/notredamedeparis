using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	private Vector3 moveDirection = Vector3.zero;
	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		CharacterController controller = GetComponent<CharacterController>();
		var z = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", z);
		if (z > 0)
			transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
		else if (z < 0)
			transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

		if (controller.isGrounded) {
			moveDirection = new Vector3 (0, 0, Mathf.Abs(z));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
		} 
		else {
			moveDirection.x += z * Time.deltaTime * 30;
			moveDirection.x = moveDirection.x > speed ? speed : moveDirection.x;
			moveDirection.x = moveDirection.x < 0 - speed ? 0 - speed : moveDirection.x;
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}