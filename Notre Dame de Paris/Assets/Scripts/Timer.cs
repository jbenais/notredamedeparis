using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float time = 60f;
	public Text text;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);
	}
		
	// Update is called once per frame
	void Update () {
		if (time > 60f) {
			gameObject.SetActive (false);
		}
		text.text = "00:" + (time < 10 ? "0" : "") + time;
		time -= Time.deltaTime;
	}

	public float getTime() {
		return time;
	}
}
