using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PressurePlateBehavior : MonoBehaviour {
	public GameObject door;
	public GameObject trigger;
	public Text chronoText;

	private float timer = 0f;
	private TriggerLevel1 level1;

	void Start() {
		level1 = trigger.GetComponent<TriggerLevel1> ();
	}

	void Update () {
		if (timer > 0f) {
			chronoText.text = "Atteignez la porte ! " + timer.ToString("F2");
			level1.stagePass = true;
			timer -= Time.deltaTime;
			if (timer <= 0)
				chronoText.text = "Réessayer ! 0.00";
			door.transform.SetPositionAndRotation (new Vector3 (12.3f, 15.9f, 24.6f),
				Quaternion.Euler (new Vector3 (0, 90, 0)));
		} else {
			level1.stagePass = false;
			door.transform.SetPositionAndRotation (new Vector3 (11.85f, 15.9f, 25.1f),
				Quaternion.Euler (new Vector3 (0, 180, 0)));
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			transform.localPosition = new Vector3 (0, 0.1f, 0);
			timer = 7f;
		}
		else
			transform.localPosition = new Vector3 (0, 0.5f, 0);
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "Player") {
			transform.localPosition = new Vector3 (0, 0.5f, 0);
		}
	}
}
