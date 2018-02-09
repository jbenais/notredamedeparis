using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManaging : MonoBehaviour {
	public GameObject mainCamera;
	public bool levelRightRotation = false;
	public float rotationSpeed = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if (levelRightRotation)
			//level.transform.Rotate (new Vector3(0, -1 * Time.deltaTime * rotationSpeed, 0));
			
	}

	public void RestartGame() {
		SceneManager.LoadScene ("Level_0");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
