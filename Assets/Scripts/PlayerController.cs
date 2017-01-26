using UnityEngine;

public class PlayerController : MonoBehaviour
{
	int MoveSpeed = 10;

	void Update()
	{
		float MoveForward = Input.GetAxis("Vertical")*MoveSpeed*Time.deltaTime;
		//this turning only for into level
		float Turning = Input.GetAxis ("Horizontal") * MoveSpeed * Time.deltaTime;

		// Move the player
		transform.Translate(Vector3.right * MoveForward);

		//bool left = Input.GetKeyDown (KeyCode.UpArrow);
//		float steer = Input.GetAxis ("Horizontal")*MoveSpeed*Time.deltaTime;
//		transform.position = new Vector3 (steer, 2f, 0);
		//transform.Translate(Vector3.left * Turning);

		//turn horizontal
		transform.Rotate(0, Turning, 0,Space.World);


		/* To-Do 
		 * if in intersection, then turn will turn 90 degree angle in either left or right
		 * if on the normal road, then turn will be normal but less than 90 degree 
		 * ban user reverse, down arrow will use for E-break
		 * Space bar to pick up passager
		 * passager range indicate for pick up- enter the green circle passager indicated
		 * drop the passager for more value
		 * connect HUD display for points and map
		 */
	}
}