using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour {
	public Vector3 lastPosition;
	public GameObject player;
	void Start() {
		lastPosition = transform.position;
	}
	private void OnTriggerEnter(Collider other) {
		player = other.gameObject;
	}

	private void OnTriggerExit(Collider other) {
		player = null;
	}

	void LateUpdate() {
		if (player != null) {
			Vector3 difference = transform.position - lastPosition;
			player.transform.Translate (difference, transform);
		}
		lastPosition = transform.position;
	}
}
