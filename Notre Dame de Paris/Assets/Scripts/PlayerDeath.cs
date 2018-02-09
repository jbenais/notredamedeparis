using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

	public bool dead = false;
	public GameObject main_camera;
	public GameObject RestartMenu;
	private Vector3 dest = Vector3.zero;
	private Vector3 velocity = Vector3.zero;
	private Animator anim;
	private bool restarting = false;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (dead) {
			if (dest == Vector3.zero) {
				dest = transform.position;
				dest.z -= 2;
				dest.y += 1;
				anim.SetFloat ("Speed", 0f);
			}
			if (main_camera.transform.position.z < (dest - new Vector3 (0, 0, 1.5f)).z)
				main_camera.transform.position = Vector3.SmoothDamp (main_camera.transform.position, dest, ref velocity, 1f);
			else if (main_camera.transform.position.z > (dest - new Vector3 (0, 0, 1.6f)).z) {
				anim.SetBool ("Death", true);
				dead = false;
				RestartMenu.SetActive (true);
			}
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Ennemy" && !restarting) {
			GetComponent<PlayerController>().enabled = false;
			dead = true;
			restarting = true;
		}
	}
}
