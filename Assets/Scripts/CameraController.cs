using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public float smooth= 5.0f;
	public float yRotation = 90f;
	public float xRotation = 40f;
	public float camDist = -16f;
	public float camHeight = 20f;

	void Start(){
		
	}

	void  Update (){
		Vector3 updatePos = target.position;
		updatePos.y += camHeight;
		updatePos.x += camDist;

		//TO-DO rotation angle
		//yRotation += Input.GetAxis("Horizontal");
		transform.eulerAngles = new Vector3(xRotation, yRotation, 0);

		//following position
		transform.position = Vector3.Lerp (
			transform.position, updatePos,
			Time.deltaTime * smooth);

		//TO-DO camera rotation angle

	} 
}
/*
 // The target we are following
public  Transform target;
// The distance in the x-z plane to the target
public int distance = 10.0;
// the height we want the camera to be above the target
public int height = 10.0;
// How much we 
public heightDamping = 2.0;
public rotationDamping = 0.6;


void  LateUpdate (){
	// Early out if we don't have a target
	if (TargetScript.russ == true){
		if (!target)
			return;

		// Calculate the current rotation angles
		wantedRotationAngle = target.eulerAngles.y;
		wantedHeight = target.position.y + height;

		currentRotationAngle = transform.eulerAngles.y;
		currentHeight = transform.position.y;

		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = target.position;
		transform.position -= currentRotation * Vector3.forward * distance;

		// Set the height of the camera
		transform.position.y = currentHeight;

		// Always look at the target
		transform.LookAt (target);
	}
} 
*/ 
