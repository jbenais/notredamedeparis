using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		yaw += speedH * Input.GetAxis ("Mouse X");
		pitch -= speedV * Input.GetAxis ("Mouse Y");
		transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);
		transform.position = player.transform.position + offset;
	}
}
