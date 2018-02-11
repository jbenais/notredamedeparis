using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		anim.SetBool ("isOpen", false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<Player3DController> ().getKeys() == 3) {
			anim.SetBool ("isOpen", true);
		}
	}
}
	