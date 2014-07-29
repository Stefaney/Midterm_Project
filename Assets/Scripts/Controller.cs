using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	float jumpSpeed = 150f;
	float gravity = 1f;
	float mouseSpeed = 50f;
	float walkingSpeed = 20f;
	int keyCounter = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Mouse Controls, slghtly different from the one in class, since I need my player to be able to look around
		float XView = mouseSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
		float YView = mouseSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
		transform.Rotate(YView, XView, 0);
	
	}
	
	void FixedUpdate()
	{	
		//creates a controller
		CharacterController controller = GetComponent<CharacterController>();

		//Character controller moves forward and back
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		float forwardSpeed = walkingSpeed * Input.GetAxis("Vertical");
		controller.SimpleMove(forward * forwardSpeed);

		//Character controller that moves sideways
		Vector3 sideways = transform.TransformDirection (Vector3.right);
		float sidewaysSpeed = walkingSpeed * Input.GetAxis ("Horizontal");
		controller.SimpleMove(sideways * sidewaysSpeed);

		//statement to test if player is on the groud; if not causing them to jump up then applying gravity 
		Vector3 up = Vector3.zero;
		if (Input.GetKeyDown (KeyCode.Space)){

			if(controller.isGrounded)
			{ 
				up.y= jumpSpeed;
			}
		
			up.y -= gravity * Time.deltaTime;
		
			controller.Move(up * Time.deltaTime);
		}

	}
	//Handles when the player touches anything with a trigger. Adds to the key counter so that the player can "collect" 5 keys.
	//Destroys every trigger object that it touches except Key which is killed in its own script. 
	void OnTriggerEnter(Collider collide)
	{
		if (collide.gameObject.tag == "Key")
		{
			keyCounter++;
		}
		if (collide.gameObject.tag == "Door" && keyCounter == 5)
		{
			Destroy(collide.gameObject);
		}
		if (collide.gameObject.tag == "Prize")
		{
			Destroy(collide.gameObject);
		}

	}

}

