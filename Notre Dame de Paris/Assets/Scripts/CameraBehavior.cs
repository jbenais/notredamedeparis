using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
	public Transform playerPos;
	public Transform[] checkPoints;
	public float speed = 5f;
	public bool moveRight = false;

	private Vector3 floorOne;
	private Vector3 floorTwo;
	private Vector3 velocity;
	private int step = 0;

	void Start() {
		floorOne = transform.position;
		floorTwo = new Vector3 (0, 11, 9);
	}
	
	// Update is called once per frame
	void Update () {
		checkFloor ();
		if (moveRight)
			moveToRight ();
	}

	void checkFloor() {
		if (playerPos.position.y > 8.8f && transform.position.y < floorTwo.y - 0.5f) {
			transform.position = Vector3.SmoothDamp (transform.position, floorTwo, ref velocity, 1f);
		}
		else if (playerPos.position.y < 8.8f && transform.position.y > floorOne.y + 0.5f)
			transform.position = Vector3.SmoothDamp (transform.position, floorOne, ref velocity, 1f);
	}

	void moveToRight() {
		if (step < checkPoints.Length) {
			transform.position = Vector3.MoveTowards (transform.position, checkPoints[step].position, speed * Time.deltaTime);
			transform.LookAt (new Vector3 (0, 5.5f, 25));
			if (transform.position == checkPoints [step].position)
				step++;
		}
	}

}


