using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	// Use this for initialization
	void Start () {
		gameObject.SetActive(true);
	}

	public void StopMenu() {
		gameObject.SetActive (false);
	}
}
