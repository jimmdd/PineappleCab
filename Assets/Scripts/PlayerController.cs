using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public int MoveSpeed = 10;
	public float laneChange = 5;
	public Transform carCamera;
	public int cameraAngle = 90;
	private bool isIntersec = false;//determin if get into the intersection zone
	private int turn_Count = 0;
	private float distance = 30;
	public bool damaged = false;
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
	public bool tutorial = false; //tutorial mode
	public Transform pivot;
	public GameObject leftSign;
	public GameObject rightSign;
	public GameObject upSign;

	void Start(){
		leftSign.SetActive (false);
		rightSign.SetActive (false);
	}

	/* To-Do 
		 * ban user reverse, down arrow will use for break(maybe feature, not useful for break)
		 * Space bar to pick up passager
		 * passager range indicate for pick up- enter the green circle passager indicated
		 * drop the passager for more value
		 */

	void Update()
	{
		
		float MoveForward = Input.GetAxis ("Vertical") * MoveSpeed * Time.deltaTime;
		transform.Translate (Vector3.right * MoveForward);

		//lane change on normal road, turn 90 degree when enter intersection
		//turn left
		if (Input.GetKeyDown(KeyCode.LeftArrow)){

			if (!isIntersec)
				transform.Translate (Vector3.down * laneChange);
			else if (turn_Count == 0) {
				transform.RotateAround (transform.position, Vector3.up, -90);
				carCamera.GetComponent<CameraController> ().cameraRotation (-90);
				turn_Count++;
			}
			leftSign.SetActive(false);
		}

		//turn right
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			if (!isIntersec)
				transform.Translate (Vector3.up * laneChange);
			else if (turn_Count == 0) {
				transform.RotateAround (transform.position, Vector3.up, 90);
				carCamera.GetComponent<CameraController> ().cameraRotation (90);
				turn_Count++;
			}
			rightSign.SetActive (false);
		}

		//RAYCASTING FOR TURNING SIGNS
		RaycastHit hit;
		Vector3 raycastDir =  pivot.transform.position - transform.position; //create the direction of the raycast that always points to the front of the car
		Ray forwardRay = new Ray (transform.position, raycastDir);
		if (Physics.Raycast (forwardRay, out hit, distance)) {
			upSign.SetActive (false);

			if (hit.collider.tag == "left_sign") {
				leftSign.SetActive (true);
			}
			if (hit.collider.tag == "right_sign") {
				rightSign.SetActive (true);
			}
			if (hit.collider.tag == "up_sign") {
				upSign.SetActive (true);
			}

		}
		//ONLY SHOW THE UP SIGN WHEN DOING TUTORIAL
		else if(tutorial){
			upSign.SetActive (true);
		}

	}

	//SHOW DAMAGE AND FLASH THE SCREEN WHEN CRASH TO THE CARS 
	void damage(){
		// If the player has just been damaged...
		if (damaged) {
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
			//playerAudio [1].Play ();
		}
		// Otherwise...
		else {
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

		}

		// Reset the damaged flag.
		damaged = false;
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
			Debug.Log("ROAD!");
			turn_Count = 0;//reset turn count
		}
		if (other.tag == "die"){
			//TO-DO CHANGE THE SCENE TO GAME OVER
			GameObject.Find("GameManager").GetComponent<GameManager>().LoadScene("Gameover");
		}
	}

}