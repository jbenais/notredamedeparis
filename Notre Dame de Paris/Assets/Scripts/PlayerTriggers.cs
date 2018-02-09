using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerTriggers : MonoBehaviour {

	private Dictionary<string, int> inventory;
	public Text keyInfo;

	void Start() 
	{
		inventory = new Dictionary<string, int>();
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
				col.gameObject.SetActive (false);
				inventory ["key"]--;
				keyInfo.text = "Key(s) : " + inventory ["key"];
				SceneManager.LoadScene("Level_01");
			}
		}
	}
}
