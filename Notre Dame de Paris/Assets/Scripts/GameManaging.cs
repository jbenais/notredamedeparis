using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManaging : MonoBehaviour {

	public GameObject player;
	public Transform[] playerCheckpoints;
	public bool playerToRight = false;
	private int playerStep = 1;

	public GameObject mainCamera;
	public Transform[] cameraCheckPoints;
	public bool cameraToRight = false;
	private int cameraStep = 0;
	
	// Update is called once per frame
	void Update () {
		if (playerToRight) {
			player.GetComponent<PlayerController> ().firstAxis = false;
			player.GetComponent<PlayerController> ().enabled = false;
			PlayerFrontToRight ();
		}

		if (cameraToRight)
			CameraMoveToRight ();
	}

	public void PlayerFrontToRight() {
		player.transform.LookAt (playerCheckpoints [playerStep].transform.position);
		player.transform.position = Vector3.MoveTowards (player.transform.position, playerCheckpoints [playerStep].position, 2f * Time.deltaTime);
		if (player.transform.position == playerCheckpoints[playerStep].position)
			playerStep++;
		if (playerStep > 2) {
			playerToRight = false;
		}
	}

	void CameraMoveToRight() {
		if (cameraStep < cameraCheckPoints.Length) {
			cameraCheckPoints [cameraStep].position = new Vector3 (cameraCheckPoints [cameraStep].position.x, mainCamera.transform.position.y, cameraCheckPoints [cameraStep].position.z);
			mainCamera.transform.position = Vector3.MoveTowards (mainCamera.transform.position, cameraCheckPoints [cameraStep].position, 15f * Time.deltaTime);
			mainCamera.transform.LookAt (new Vector3 (0, mainCamera.transform.position.y, 25));
			if (mainCamera.transform.position == cameraCheckPoints [cameraStep].position)
				cameraStep++;
		} else {
			cameraToRight = false;
			player.GetComponent<PlayerController> ().enabled = true;
			mainCamera.GetComponent<CameraBehavior> ().SetFloors (new Vector3(mainCamera.transform.position.x, 5.5f, mainCamera.transform.position.z),
				new Vector3(mainCamera.transform.position.x, 11f, mainCamera.transform.position.z));

		}
	}

	public void RestartGame() {
		SceneManager.LoadScene ("Level_0");
	}

	public void QuitGame() {
		Application.Quit ();
	}
}
