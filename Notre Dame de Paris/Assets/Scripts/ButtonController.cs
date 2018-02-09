using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject flames;
	private float timer = 0f;
	private bool begin = false;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (timer >= 5f) {
			if (begin) {
				flames.GetComponent<ParticleSystem> ().Stop ();
			} else {
				flames.GetComponent<ParticleSystem> ().Play ();
			}
			timer = 0f;
		}
		begin = !begin;
		timer += Time.deltaTime;
	}

	void OnTriggerEnter (Collider other) {
		begin = other.gameObject.tag == "Player";
	}
}
