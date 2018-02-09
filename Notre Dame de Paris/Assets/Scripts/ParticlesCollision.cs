﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesCollision : MonoBehaviour {
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player3DController> ().die ();
		}
	}
}
