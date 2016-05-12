using UnityEngine;
using System.Collections;

/// <summary>
/// This is a basic controller for a WASD control scheme 
/// </summary>
[RequireComponent (typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour {
	
	/// <summary>
	/// movement force for the object, more force will move it faster.
	/// Remember to tweak this depending of the mass of your rigid body.
	/// </summary>
	public float movementForce = 0.5f; 

	public float jumpForce = 10;
	
	// Use this for initialization
	void Start () {
	}
	
	
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		if (horizontal < 0){
			transform.rotation = Quaternion.Euler (0, 270, 0);
		}
		if (horizontal > 0){
			transform.rotation = Quaternion.Euler (0, 90, 0);
		}

		GetComponent<Rigidbody> ().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, horizontal * movementForce);
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
		Ray downRay = new Ray (transform.position, -Vector3.up);
		Physics.Raycast (downRay, out hit);
		//Debug.Log (hit.distance);

		if (Input.GetButton ("Jump") && hit.distance < 1.1) {
			GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody>().velocity.x, jumpForce, GetComponent<Rigidbody>().velocity.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
