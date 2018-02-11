using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour {
	// Use this for initialization
	private float timer;
	private bool play = true;

	void Start () {
	}
	// Update is called once per frame
	void Update () {
		if (timer >= 5f) {
			play = !play;
			if (play) {
				gameObject.GetComponent<ParticleSystem>().Play();
				gameObject.GetComponent<CapsuleCollider> ().enabled = true;
			} else {
				gameObject.GetComponent<ParticleSystem>().Stop();
				gameObject.GetComponent<CapsuleCollider> ().enabled = false;
			}
			timer = 0;
		}
		timer += Time.deltaTime;
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player" && play) {
			other.gameObject.GetComponent<Player3DController> ().die ();
		}
	}
}
