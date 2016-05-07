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
	public float movementForce; 
	
	
	private float horizontal;
	private float vertical;
	
	
	// Use this for initialization
	void Start () {		
		
	}
	
	
	void FixedUpdate()
	{
		
	// WE move the rigid body depending of the input.	
		if (horizontal < 0)
		{
			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.left * movementForce);
		}
		
		if (horizontal > 0)
		{
			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.right * movementForce);
		}
		
		if (vertical < 0)
		{
			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.back * movementForce);
		}
		
		if (vertical > 0)
		{
			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().rotation * Vector3.forward * movementForce);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// we register the input so the fixed update knows what to do with the rigid body.
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");		
		
	}
}
