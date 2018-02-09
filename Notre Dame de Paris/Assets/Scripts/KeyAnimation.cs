using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAnimation : MonoBehaviour {
	public float rotationSpeed = 100;

	void FixedUpdate () {
		transform.Rotate (new Vector3 (0, Time.deltaTime * rotationSpeed, 0));
	}
}