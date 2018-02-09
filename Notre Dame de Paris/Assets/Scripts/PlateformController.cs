using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformController : MonoBehaviour {
	// Use this for initialization
	bool direction = true;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x <= -90 || transform.position.x >= 90)
			direction = !direction; 
		transform.Translate (new Vector3 ((direction ? 0.4f : -0.4f), 0, 0));
	}
}
