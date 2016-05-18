using UnityEngine;
using System.Collections;

/// <summary>
/// This is a basic controller for a WASD control scheme 
/// </summary>
[RequireComponent (typeof(Rigidbody))]
public class P_Movement : MonoBehaviour
{
	/// <summary>
	/// movement force for the object, more force will move it faster.
	/// Remember to tweak this depending of the mass of your rigid body.
	/// </summary>
	public float movementForce = 0.5f; 

	public float jumpForce = 10;
	public float g = -9.81f;
	public GameObject Player1;
	public GameObject Player2;

	void Start(){
		Physics.gravity = new Vector3(0, g, 0);	
	}

	void FixedUpdate()
	{
		if(Player1)
		{
			//Player 1:
			float horizontal = Input.GetAxis ("P1_Horizontal");
			float vertical = Input.GetAxis ("P1_Vertical");
			if (horizontal < 0) {
				Player1.transform.rotation = Quaternion.Euler (0, 270, 0);
			}
			if (horizontal > 0) {
				Player1.transform.rotation = Quaternion.Euler (0, 90, 0);
			}

			Player1.GetComponent<Rigidbody> ().velocity = new Vector3 (Player1.GetComponent<Rigidbody> ().velocity.x, Player1.GetComponent<Rigidbody> ().velocity.y, horizontal * movementForce);
			//WE move the rigid body depending of the input.
			//		if (vertical < 0)
			//		{
			//			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.back * movementForce);
			//		}
			//		
			//		if (vertical > 0)
			//		{
			//			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.forward * movementForce);
			//		}

			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray (Player1.transform.position, -Vector3.up);
			Physics.Raycast (downRay, out hit);

			if(Input.GetButton ("P1_Jump") && hit.distance < 1.1)
				Player1.GetComponent<Rigidbody> ().velocity = new Vector3 (Player1.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player1.GetComponent<Rigidbody> ().velocity.z);
		}

		if(Player2)
		{
			//Player 2:
			float horizontal = Input.GetAxis ("P2_Horizontal");
			float vertical = Input.GetAxis ("P2_Vertical");
			if (horizontal < 0) {
				Player2.transform.rotation = Quaternion.Euler (0, 270, 0);
			}
			if (horizontal > 0) {
				Player2.transform.rotation = Quaternion.Euler (0, 90, 0);
			}

			Player2.GetComponent<Rigidbody> ().velocity = new Vector3 (Player2.GetComponent<Rigidbody> ().velocity.x, Player2.GetComponent<Rigidbody> ().velocity.y, horizontal * movementForce);
			//WE move the rigid body depending of the input.
			//		if (vertical < 0)
			//		{
			//			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.back * movementForce);
			//		}
			//		
			//		if (vertical > 0)
			//		{
			//			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.forward * movementForce);
			//		}

			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray (Player2.transform.position, -Vector3.up);
			Physics.Raycast (downRay, out hit);

			if(Input.GetButton ("P2_Jump") && hit.distance < 1.1)
				Player2.GetComponent<Rigidbody> ().velocity = new Vector3 (Player2.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player2.GetComponent<Rigidbody> ().velocity.z);
		}
	}
}