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
//	public float grappleDistance = 5.0f;
//	public float grappleHook = 5.0f;
	public float jumpForce = 10;
	public float g = -9.81f;
	public GameObject [] grapplePoints;
	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;

	public bool BeingCarried1 = false;
	public bool BeingCarried2 = false;
	public bool BeingCarried3 = false;

	public bool FacingRight1 = false;
	public bool FacingRight2 = false;
	public bool FacingRight3 = false;
	

	void Start(){
		Physics.gravity = new Vector3(0, g, 0);
//		grapplePoints = GameObject.FindGameObjectsWithTag("gp");
	}

	void FixedUpdate()
	{
		if(Player1)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray (Player1.transform.position, -Vector3.up);
			Physics.Raycast (downRay, out hit);

			if (hit.distance < 1.1) {
				BeingCarried1 = false;
			}

			if (Input.GetButton ("P1_Jump") && hit.distance < 1.1) {
				if(GameObject.Find("Player1").GetComponent<P_PickUp>().Carrying == false){
					Player1.GetComponent<Rigidbody> ().velocity = new Vector3 (Player1.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player1.GetComponent<Rigidbody> ().velocity.z);
				}
			}

			if(!BeingCarried1){
			//Player 1:
			float horizontal = Input.GetAxis ("P1_Horizontal");
			//float vertical = Input.GetAxis ("P1_Vertical");
			if (horizontal < 0) {
				Player1.transform.rotation = Quaternion.Euler (0, 270, 0);
				FacingRight1 = false;
			}
			if (horizontal > 0) {
				Player1.transform.rotation = Quaternion.Euler (0, 90, 0);
				FacingRight1 = true;
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
			}
		}

		if(Player2)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray (Player2.transform.position, -Vector3.up);
			Physics.Raycast (downRay, out hit);

			if (hit.distance < 1.1) {
				BeingCarried2 = false;
			}

			if (Input.GetButton ("P2_Jump") && hit.distance < 1.1) {
				if(GameObject.Find("Player2").GetComponent<P_PickUp>().Carrying == false){
					Player2.GetComponent<Rigidbody> ().velocity = new Vector3 (Player2.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player2.GetComponent<Rigidbody> ().velocity.z);
				}
			}

			if(!BeingCarried2){
			//Player 2:
			float horizontal = Input.GetAxis ("P2_Horizontal");
			//float vertical = Input.GetAxis ("P2_Vertical");
			if (horizontal < 0) {
				Player2.transform.rotation = Quaternion.Euler (0, 270, 0);
				FacingRight2 = false;
			}
			if (horizontal > 0) {
				Player2.transform.rotation = Quaternion.Euler (0, 90, 0);
				FacingRight2 = true;
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

			
		}

		if(Player3)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit3;
			Ray downRay3 = new Ray (Player3.transform.position, -Vector3.up);
			Physics.Raycast (downRay3, out hit3);

			if (hit3.distance < 1.1) {
				BeingCarried3 = false;
			}

			if (Input.GetButton ("P3_Jump") && hit3.distance < 1.1) {
				if(GameObject.Find("Player3").GetComponent<P_PickUp>().Carrying == false){
					Player3.GetComponent<Rigidbody> ().velocity = new Vector3 (Player3.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player3.GetComponent<Rigidbody> ().velocity.z);
				}
			}

			if(!BeingCarried3){
			//Player 3:
			float horizontal = Input.GetAxis ("P3_Horizontal");
			//float vertical = Input.GetAxis ("P3_Vertical");
			if (horizontal < 0) {
				Player3.transform.rotation = Quaternion.Euler (0, 270, 0);
				FacingRight3 = false;
			}
			if (horizontal > 0) {
				Player3.transform.rotation = Quaternion.Euler (0, 90, 0);
				FacingRight3 = true;
			}

			Player3.GetComponent<Rigidbody> ().velocity = new Vector3 (Player3.GetComponent<Rigidbody> ().velocity.x, Player3.GetComponent<Rigidbody> ().velocity.y, horizontal * movementForce);
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

			
		}
//		//if distance between player and grappling hook < some value, create a hinge
//		foreach(GameObject gPoint in grapplePoints){
//			if(Vector3.Distance(Player1.transform.position, gPoint) > grappleDistance){}
//		}
		}
	}
}
}