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

	public GameObject Player1Anim;
	public GameObject Player2Anim;
	public GameObject Player3Anim;

	public bool BeingCarried1 = false;
	public bool BeingCarried2 = false;
	public bool BeingCarried3 = false;

	public bool FacingRight1 = false;
	public bool FacingRight2 = false;
	public bool FacingRight3 = false;

	public bool P1OnGround = true;
	public bool P2OnGround = true;
	public bool P3OnGround = true;

	public int layerMask;

	void Start(){
		Physics.gravity = new Vector3(0, g, 0);
		var layerMask = ((1 << 11) | (1 << 12));
		//layerMask = ~(11 << LayerMask.NameToLayer ("Player")); // ignore collisions with layerX
//		grapplePoints = GameObject.FindGameObjectsWithTag("gp");
	}

	void FixedUpdate()
	{

		//Debug.Log(layerMask.ToString());
		if(Player1)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray (Player1.transform.position, -Vector3.up);
			Physics.Raycast (downRay, out hit, Mathf.Infinity, layerMask);

			if (hit.distance < 1.1) {
				BeingCarried1 = false;
				P1OnGround = true;
			} else {
				P1OnGround = false;
				//Player1Anim.GetComponent<Animator> ().Play ("Idle");
			}

			if (Input.GetButton ("P1_Jump") && hit.distance < 1.1) {
				Player1Anim.GetComponent<Animator> ().Play ("Jump");
				if (GameObject.Find ("Player1").transform.GetChild (2).GetComponent<P_PickUp> ().Carrying == false) {
					Player1.GetComponent<Rigidbody> ().velocity = new Vector3 (Player1.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player1.GetComponent<Rigidbody> ().velocity.z);
				}
			} else {
				
			}

			if(!BeingCarried1){
			

					

			//Player 1:
			float horizontal = Input.GetAxis ("P1_Horizontal");
			//float vertical = Input.GetAxis ("P1_Vertical");
				if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
					if (hit.distance < 1.1) 
						Player1Anim.GetComponent<Animator> ().Play ("Idle");
					GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<M_AudioManager> ().SoundFXOutput.Stop();
				}
				
			if (horizontal < 0) {
				Player1.transform.rotation = Quaternion.Euler (0, 270, 0);
					GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
					if (hit.distance < 1.1) 
						Player1Anim.GetComponent<Animator>().Play("Walk");
				FacingRight1 = false;
			}
			if (horizontal > 0) {
				Player1.transform.rotation = Quaternion.Euler (0, 90, 0);
					GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
					if (hit.distance < 1.1) 
						Player1Anim.GetComponent<Animator>().Play("Walk");
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

		if (Player2) {
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray (Player2.transform.position, -Vector3.up);
			Physics.Raycast (downRay, out hit, Mathf.Infinity, layerMask);

			if (hit.distance < 1.1) {
				BeingCarried2 = false;
				P2OnGround = true;

			} else {
				P2OnGround = false;

			}

			if (Input.GetButton ("P2_Jump") && hit.distance < 1.1) {
				Player2Anim.GetComponent<Animator> ().Play ("Jump");
				if (GameObject.Find ("Player2").transform.GetChild (2).GetComponent<P_PickUp> ().Carrying == false) {
					Player2.GetComponent<Rigidbody> ().velocity = new Vector3 (Player2.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player2.GetComponent<Rigidbody> ().velocity.z);
					Player2Anim.GetComponent<Animator> ().Play ("Jump");
				}
			}

			if (!BeingCarried2) {
				//Player 2:
				float horizontal = Input.GetAxis ("P2_Horizontal");
				//float vertical = Input.GetAxis ("P2_Vertical");

				if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D))
				if (hit.distance < 1.1)
					Player2Anim.GetComponent<Animator> ().Play ("Idle");
				
				if (horizontal < 0) {
					Player2.transform.rotation = Quaternion.Euler (0, 270, 0);
					if (hit.distance < 1.1)
						Player2Anim.GetComponent<Animator> ().Play ("Walk");
					FacingRight2 = false;
				}
				if (horizontal > 0) {
					Player2.transform.rotation = Quaternion.Euler (0, 90, 0);
					if (hit.distance < 1.1)
						Player2Anim.GetComponent<Animator> ().Play ("Walk");
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
		}
		if(Player3)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray (Player3.transform.position, -Vector3.up);
			Physics.Raycast (downRay, out hit, Mathf.Infinity, layerMask);

				if (hit.distance < 1.1) {
					BeingCarried3 = false;
					P3OnGround = true;
				} else {
					P3OnGround = false;
				}

			if (Input.GetButton ("P3_Jump") && hit.distance < 1.1) {
					Player3Anim.GetComponent<Animator> ().Play ("Jump");
				if(GameObject.Find("Player3").transform.GetChild(2).GetComponent<P_PickUp>().Carrying == false){
					Player3.GetComponent<Rigidbody> ().velocity = new Vector3 (Player3.GetComponent<Rigidbody> ().velocity.x, jumpForce, Player3.GetComponent<Rigidbody> ().velocity.z);
						Player3Anim.GetComponent<Animator> ().Play ("Jump");
					}
			}

			if(!BeingCarried3){
			//Player 3:
			float horizontal = Input.GetAxis ("P3_Horizontal");
			//float vertical = Input.GetAxis ("P3_Vertical");

			if(!Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L))
				if (hit.distance < 1.1)
					Player3Anim.GetComponent<Animator> ().Play ("Idle");
				
			if (horizontal < 0) {
				Player3.transform.rotation = Quaternion.Euler (0, 270, 0);
					if (hit.distance < 1.1)
						Player3Anim.GetComponent<Animator>().Play("Walk");
				FacingRight3 = false;
			}
			if (horizontal > 0) {
				Player3.transform.rotation = Quaternion.Euler (0, 90, 0);
					if (hit.distance < 1.1)
						Player3Anim.GetComponent<Animator>().Play("Walk");
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