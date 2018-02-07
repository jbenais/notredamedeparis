using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCharacter : MonoBehaviour {

	void Start() {
	}
	private void OnCollisionEnter(Collision other) {
		transform.parent = other.gameObject.transform;

	}

	private void OnCollisionExit(Collision other) {
		transform.parent = null;
	}
}
