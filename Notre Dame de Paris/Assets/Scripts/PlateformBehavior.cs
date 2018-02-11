using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformBehavior : MonoBehaviour {

	public string direction = "right";
	public float speed = 10f;
	public float timeMove = 2f;

	private float timeOrigin;
	private Vector3 dir;
	private bool go = true;

	// Use this for initialization
	void Start () {
		switch (direction) {
		case "left":
			dir = -transform.right;
			break;
		case "up":
			dir = transform.up;
			break;
		case "down":
			dir = -transform.up;
			break;
		default:
			dir = transform.right;
			break;
		}
		timeOrigin = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - timeOrigin > timeMove) {
			go = !go;
			timeOrigin = Time.time;
		}
		transform.Translate((go ? dir : -dir) * Time.deltaTime);
	}
}
