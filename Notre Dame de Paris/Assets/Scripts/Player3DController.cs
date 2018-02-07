using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3DController : MonoBehaviour {

	public GameObject Camera;
	public float speed;
	public float jumpForce;

	void Start() {
		speed = 30f;
		jumpForce = 10f;
	}

	void Update() {
		if (Input.GetKey (KeyCode.UpArrow) || (Input.GetKey (KeyCode.Z))) {
			transform.Translate ((-Camera.transform.forward) * speed * Time.deltaTime);
		} 
		if (Input.GetKey (KeyCode.DownArrow) || (Input.GetKey (KeyCode.S))) {
			transform.Translate ((Camera.transform.forward) * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow) || (Input.GetKey (KeyCode.Q))) {
			transform.Translate((Camera.transform.right) * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow) || (Input.GetKey (KeyCode.D))) {
			transform.Translate((-Camera.transform.right) * speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.Space)) {
			transform.Translate (Vector3.up * 3);
			//GetComponent<Rigidbody> ().velocity = new Vector3 (0, jumpForce, 0);
		}
	}
}
