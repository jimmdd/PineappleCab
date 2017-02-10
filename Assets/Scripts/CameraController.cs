using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public Transform forwardTarget;
	public float smooth= 5.0f;
	public float yRotation = 90f;
	public float xRotation = 40f;
	//public float camDist = -16f;
	public float camHeight = 40f;
	public bool isTurning = false; //used for contorl turning camera rotation
	public Vector3 updatePos;

	void  Update (){
		updatePos = forwardTarget.position;
		updatePos.y += camHeight;
		//updatePos.x += camDist;

		//camera position moves towards target position:
		transform.position = Vector3.Lerp (transform.position, updatePos,Time.deltaTime * smooth);

	} 

	//allow horizontally rotate the camera and then align with the player
	public void cameraRotation(float angle){
		transform.RotateAround (transform.position, Vector3.up, angle);
		transform.position = updatePos;
	}

	//allow vertical rotate of the camera NOT WORKING FOR TURNING
	public void cameraTilt(float x, float y){
		transform.eulerAngles = new Vector3 (x, y, 0);
	}
}

