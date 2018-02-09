using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

	public GameObject player;
	public Text resultText;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
	}

	public void ToggleEndMenu() {
		gameObject.SetActive(true);
		player.GetComponent<CharacterController> ().enabled = false;
	}

	public void Restart() {
		gameObject.SetActive (false);
		SceneManager.LoadScene("Level_0");
	}

	public void quit() {
		Application.Quit ();
	}

	public void win() {
		resultText.color = Color.green;
		resultText.text = "YOU WIN !!!";
		ToggleEndMenu ();
	}
	public void dead() {
		resultText.text = "YOU DIED !!!";
		ToggleEndMenu ();
	}

	public void lost() {
		resultText.text = "THE PRINCESS IS DEAD !!";
		ToggleEndMenu ();
	}
}
