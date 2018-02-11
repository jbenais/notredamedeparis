using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformController : MonoBehaviour {
	// Use this for initialization
	private bool direction = true;
	public float start;
	public float end;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= start || transform.position.x <= end) {
			direction = !direction; 
		}
		transform.Translate (new Vector3 ((direction ? -0.4f : 0.4f), 0, 0));
	}
}
