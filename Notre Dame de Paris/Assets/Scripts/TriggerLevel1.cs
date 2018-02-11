using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerLevel1 : MonoBehaviour {

	public bool stagePass = false;

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player" && stagePass) {
			SceneManager.LoadScene ("Level_01");
		}
	}
}
