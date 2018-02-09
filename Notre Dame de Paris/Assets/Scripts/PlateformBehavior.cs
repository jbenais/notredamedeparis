using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformBehavior : MonoBehaviour {

	private bool go = true;
	public float speed = 10f;
	public float timeMove = 2f;
	private float timeOrigin;

	// Use this for initialization
	void Start () {
		timeOrigin = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeOrigin > timeMove) {
			go = !go;
			timeOrigin = Time.time;
		}
		transform.Translate((go ? transform.right : - transform.right) * Time.deltaTime);
	}
}
