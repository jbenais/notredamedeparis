using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision (GameObject collision) {
		Debug.Log ("OKKKK!"); 
		//if (collision.transform.tag == "player") {
		//	Debug.Log ("Joueur touché !");
		//}
	}
}
