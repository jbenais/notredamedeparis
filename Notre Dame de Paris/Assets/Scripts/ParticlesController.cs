using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour {
	// Use this for initialization
	float timer;
	bool play = true;

	void Start () {
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 5f) {
			if (play) {
				this.gameObject.GetComponent<ParticleSystem> ().Stop ();
			} else {
				this.gameObject.GetComponent<ParticleSystem> ().Play ();
			}
			timer = 0f;
		}
		play = !play;
		timer += Time.deltaTime;
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player" && play) {
			other.gameObject.GetComponent<Player3DController> ().die ();
		}
	}
}
