using UnityEngine;
using System.Collections;

public class PlatformController: MonoBehaviour {
	
	public float speed;
	public float JumpSpeed = 5.0F;
	//public float gravity = 20.0F;
	public float sensitivity;
	private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		Screen.showCursor = false; //Hide the cursor on the screen 
		Screen.lockCursor = true; //Lock the cursor inside the window
	}
	
	// Update is called once per frame
	void Update () {
		

		/*
		 * Movement code for WASD movement
		 */
		Vector3 sVec = new Vector2 ();

		if (Input.GetKey (KeyCode.W)) {
			sVec += transform.forward * speed;
		}
		if (Input.GetKey (KeyCode.S)) {
				sVec -= transform.forward * speed;
		}
		if (Input.GetKey (KeyCode.A)) {
				sVec -= transform.right * speed;
		}
		if (Input.GetKey (KeyCode.D)) {
				sVec += transform.right * speed;
		}

		CharacterController cc = GetComponent<CharacterController> ();

		cc.SimpleMove(sVec);



		/*
		 * code for jumping
		 */

		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			if (Input.GetKey(KeyCode.Space))
				moveDirection.y = JumpSpeed;
			
		}

		cc.Move(moveDirection * Time.deltaTime);

		transform.Rotate 
			(new Vector3 (0.0f, sensitivity * Input.GetAxis ("Mouse X"), 0.0f));
		}
		

		
}
