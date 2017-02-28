using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			//TO-DO 
		}
}
}
