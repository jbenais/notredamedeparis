using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {
	public Transform playerPos;

	private Vector3 floorOne;
	private Vector3 floorTwo;
	private Vector3 velocity;

	void Start() {
		floorOne = transform.position;
		floorTwo = new Vector3(transform.position.x ,transform.position.y + 5.5f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		checkFloor ();
	}

	void checkFloor() {
		if (playerPos.position.y > 8.8f && transform.position.y < floorTwo.y - 0.5f) {
			transform.position = Vector3.SmoothDamp (transform.position, floorTwo, ref velocity, 1f);
				
		}
		else if (playerPos.position.y < 8.8f && transform.position.y > floorOne.y + 0.5f)
			transform.position = Vector3.SmoothDamp (transform.position, floorOne, ref velocity, 1f);
	}

	public void SetFloors(Vector3 floorOne, Vector3 floorTwo) {
		this.floorOne = floorOne;
		this.floorTwo = floorTwo;
	}
}


