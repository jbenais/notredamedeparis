using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour {
	public void StartGame() {
		SceneManager.LoadScene ("Level_0");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
