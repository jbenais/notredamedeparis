using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

	public GameObject flames;
	private float timer = 0f;
	private bool begin = false;
	// Use this for initialization
	void Start () {
		flames.GetComponent<ParticleSystem> ().Play ();
	}

	// Update is called once per frame
	void Update () {
		if (begin && timer >= 15f) {
			timer += Time.deltaTime;
			flames.GetComponent<ParticleSystem> ().Stop ();
			//flames.GetComponent<BoxCollider> ().enabled = false;
		} else {
			begin = !begin;
			timer = 0f;
			flames.GetComponent<ParticleSystem> ().Play ();
			//flames.GetComponent<BoxCollider> ().enabled = true;
		}
	}

	void OnTriggerEnter (Collider other) {
		begin = other.gameObject.tag == "Player";
		Debug.Log ("ok il a touché");
	}
}
