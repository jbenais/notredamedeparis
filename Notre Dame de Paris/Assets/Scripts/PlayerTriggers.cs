using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour {

	private Dictionary<string, int> inventory;
	public GameManaging gm;
	public Text keyInfo;

	void Start() 
	{
		inventory = new Dictionary<string, int>();
		gm = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<GameManaging> ();
		inventory.Add ("key", 0);
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Key") {
			col.gameObject.SetActive (false);
			inventory ["key"]++;
			keyInfo.text = "Key(s) : " + inventory ["key"];
		}
		else if (col.gameObject.tag == "Door")
		{
			if (inventory ["key"] > 0) {
				if (col.gameObject.name == "Door1") {
					gm.playerToRight = true;
					gm.cameraToRight = true;
				}

				col.gameObject.SetActive (false);
				inventory ["key"]--;
				keyInfo.text = "Key(s) : " + inventory ["key"];
				//SceneManager.LoadScene("Level_01");
			}
		}/*
		else if (col.gameObject.tag == "PressurePlate") {
			col.

		}*/
	}
}
