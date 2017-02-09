using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform target;
	public Transform forwardTarget;
	public float smooth= 5.0f;
	public float yRotation = 90f;
	public float xRotation = 40f;
	public float camDist = -16f;
	public float camHeight = 40f;
	public bool isTurning = false; //used for contorl turning camera rotation

	//for camera rolling
	private Vector3 m_RollUp = Vector3.up;// The roll of the camera around the z axis ( generally this will always just be up )
    private float m_RollSpeed = 0.2f;// How fast the rig will roll (around Z axis) to match target's roll.
	private float m_TurnSpeed = 1; // How fast the rig will turn to keep up with target's rotation


	void  Update (){
		Vector3 updatePos = target.position;
		updatePos.y += camHeight;
		updatePos.x += camDist;

		//TO-DO rotation angle
		//yRotation += Input.GetAxis("Horizontal");
		transform.eulerAngles = new Vector3(xRotation, yRotation, 0);

		//camera position moves towards target position:
		transform.position = Vector3.Lerp (transform.position, updatePos,Time.deltaTime * smooth);

		//TO-DO camera rotation angle
		//transform.rotation = Quaternion.Euler(0, 90, 0);

		// camera's rotation is split into two parts, which can have independend speed settings:
		// rotating towards the target's forward direction (which encompasses its 'yaw' and 'pitch')
//		if (!m_FollowTilt)
//		{
//			targetForward.y = 0;
//			if (targetForward.sqrMagnitude < float.Epsilon)
//			{
//				targetForward = transform.forward;
//			}
//		}
		/*
		var targetForward = target.right;
		var targetUp = target.forward;
		var rollRotation = Quaternion.LookRotation(targetForward, m_RollUp);
//
//		// and aligning with the target object's up direction (i.e. its 'roll')
		//m_RollUp = m_RollSpeed > 0 ? Vector3.Slerp(m_RollUp, targetUp, m_RollSpeed*Time.deltaTime) : Vector3.up;
		transform.rotation = Quaternion.Lerp(transform.rotation, rollRotation, m_TurnSpeed*Time.deltaTime);

//		Vector3 relativePos = target.position - transform.position;
//		Quaternion rotation = Quaternion.LookRotation(relativePos);
//		transform.rotation = rotation;
*/
	} 

	public void cameraRotation(){
		//transform.rotation = Quaternion (0, 0, 90);
	}
}

