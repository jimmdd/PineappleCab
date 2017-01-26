using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoving : MonoBehaviour {

	public float MoveSpeed = 10;
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right*MoveSpeed*Time.deltaTime);
	}
}
