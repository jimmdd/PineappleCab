using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public int MoveSpeed = 10;
	public float laneChange = 5;
	public Transform camera;
	public int cameraAngle = 90;
	private bool isIntersec = false;//determin if get into the intersection zone
	private int turn_Count = 0;

	void Update()
	{
		//allow player to move forward/backward
		float MoveForward = Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
		transform.Translate (Vector3.right * MoveForward);

		//lane change on normal road, turn 90 degree when enter intersection
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
			if (!isIntersec)
				transform.Translate (Vector3.down * laneChange);
			else if (turn_Count == 0) {
				transform.RotateAround (transform.position, Vector3.up, -90);
				turn_Count++;
			}
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			if (!isIntersec)
				transform.Translate (Vector3.up * laneChange);
			else if (turn_Count == 0) {
				transform.RotateAround (transform.position, Vector3.up, 90);
				camera.transform.RotateAround (transform.position, Vector3.up, 90);
				turn_Count++;
			}
		}



		//this turning only for into level
//		float Turning = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;

		//bool left = Input.GetKeyDown (KeyCode.UpArrow);
		//float steer = Input.GetAxis ("Horizontal")*MoveSpeed*Time.deltaTime;
		//transform.position = new Vector3 (steer, 2f, 0);
//		transform.Translate (Vector3.left * Turning);

		//turn horizontal
//		transform.Rotate (0, Turning, 0, Space.World);

		//rotation of the camera with fixed axis
		//scamera.transform.rotation = Quaternion.AngleAxis (cameraAngle, Vector3.up);

		/* To-Do 
		 * if in intersection, then turn will turn 90 degree angle in either left or right
		 * if on the normal road, then turn will be normal but less than 90 degree
		 * ban user reverse, down arrow will use for break(maybe feature, not useful for break)
		 * Space bar to pick up passager
		 * passager range indicate for pick up- enter the green circle passager indicated
		 * drop the passager for more value
		 * connect HUD display for points and map
		 */

	}

	//when enter the intersection, if in intersection, then turn will turn 90 degree angle in either left or right
	void OnTriggerEnter(Collider other) {
		if(other.tag=="intersec"){
			Debug.Log ("intersection!");
			isIntersec = true;
			//TO-DO
		}
		if (other.tag == "road") {
			isIntersec = false;
			turn_Count = 0;//reset turn count
		}
	}
}