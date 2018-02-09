using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GargoyleBehavior : MonoBehaviour {

	private bool forward = true;
	//private PlayerDeath die;
	// Update is called once per frame
	void FixedUpdate () {

		if (transform.position.z < 18.8f)
			forward = false;
		else if (transform.position.z > 21f)
			forward = true;

		if (forward)
			transform.Translate (new Vector3 (0, 0, -1f) * Time.deltaTime);
		else
			transform.Translate (new Vector3 (0, 0, 1f) * Time.deltaTime);
	}
	/*
	void OnTriggerEnter (Collider col)
	{
		Debug.Log ("Collision with : " + col.gameObject.tag);
		if (col.gameObject.tag == "Player") {
			die = col.gameObject.GetComponent<PlayerDeath> ();
			die.dead = true;
		}
	}*/
}
