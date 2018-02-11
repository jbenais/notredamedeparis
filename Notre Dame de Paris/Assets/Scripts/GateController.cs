using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour {

	private Animator anim;
	private float timer;
	private bool open = false;
	// Use this for initialization
	void Start () {
		timer = 0f;
		anim = GetComponent<Animator> ();
		anim.SetBool ("isOpen", open);
	}
	
	// Update is called once per frame
	void Update () {
		if (timer >= 1.5f) {
			open = !open;
			anim.SetBool ("isOpen", open);
			timer = 0f;
		}
		timer += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			other.gameObject.GetComponent<Player3DController> ().die ();
		}
	}
}