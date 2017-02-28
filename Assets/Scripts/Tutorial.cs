using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	public GameObject player;
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (this.tag == "left_sign") {
			}
		}
	}

	//calculate the distance between two game object
	public float checkDist(Transform t1, Transform t2){
		return Vector3.Distance (t1.position, t2.position);
	}
}
