using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public GameObject player;
	private float time = 180f;
	public Text remainingTime;
	// Use this for initialization
	void Start () {
		gameObject.SetActive (true);
	}
		
	// Update is called once per frame
	void Update () {
		if (time <= 0f) {
			gameObject.SetActive (false);
			return;
		}
		int min = (int)(time / 60f);
		int sec = (int)(time % 60f);
		remainingTime.text = min.ToString("00") + ":" + sec.ToString("00");
		time -= Time.deltaTime;
	}

	public float getTime() {
		return time;
	}
}
