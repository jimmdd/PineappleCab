using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoving : MonoBehaviour {

	public float MoveSpeed = 10;
	public float delay = 10f;

	void Update () {
		transform.Translate (Vector3.right*MoveSpeed*Time.deltaTime);

		//Automatic destroy the spawned gameObject after delay time
		Object.Destroy(gameObject, delay);
	}


}
