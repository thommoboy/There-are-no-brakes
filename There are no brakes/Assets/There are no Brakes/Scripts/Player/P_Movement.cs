/***********************
 * P_Movement.cs
 * Originally Written by Joshua Garvey
 * Modified By: Pierce Thompson, Nathan Brown
 * Modifcations:
	Nathan Brown: incorporation of player interaction
	Pierce Thompson: incorporation of animations, sound effects and refactoring, Addition of controller support, cleaning of code
 ***********************/
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

	public bool P1Carrying = false;
	public bool P2Carrying = false;
	public bool P3Carrying = false;

    public bool P2Uncontroled = false;

    public bool FacingRight1 = false;
	public bool FacingRight2 = false;
	public bool FacingRight3 = false;

	public bool P1OnGround = true;
	public bool P2OnGround = true;
	public bool P3OnGround = true;
	
	//direction check for pyramid levels
	public string P1Direction = "x+";
	public string P2Direction = "x+";
	public string P3Direction = "x+";

	public int layerMask;


	void Start(){
		Physics.gravity = new Vector3(0, g, 0);
		var layerMask = ((1 << 12) | (1 << 13));
		//layerMask = ~(11 << LayerMask.NameToLayer ("Player")); // ignore collisions with layerX
//		grapplePoints = GameObject.FindGameObjectsWithTag("gp");
	}

    void FixedUpdate()
    {
		if (Player1)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray(Player1.transform.position, -Vector3.up);
			Physics.Raycast(downRay, out hit, Mathf.Infinity, layerMask);

			if (hit.distance < 1.1)
			{
				BeingCarried1 = false;
				P1OnGround = true;
			}
			else
			{
				P1OnGround = false;
			}

			if (!BeingCarried1)
			{
				if (!P1Carrying && P1OnGround)
				{
					if (hit.distance < 1.1)
					{
						if(Input.GetAxis("P1 Jump") > 0 || Input.GetAxis("A_1") > 0)
						{
							P1OnGround = false;
							Player1Anim.GetComponent<Animator>().Play("Jump");
							if (Player1.transform.GetChild(0).GetComponent<P_PickUp>().Carrying == false)
							{
								Player1.GetComponent<Rigidbody>().velocity = new Vector3(Player1.GetComponent<Rigidbody>().velocity.x, jumpForce, Player1.GetComponent<Rigidbody>().velocity.z);
							}
						}
					}
				}

				//Player 1:
				float horizontal = Input.GetAxis("P1 Horizontal");
				float horizontal2 = Input.GetAxis("L_XAxis_1");
				//if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
				if (horizontal == 0 && horizontal2 == 0)
				{
					if(P1OnGround)
					{
						Player1.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
					}
					if (hit.distance < 1.1)
					{
						Player1Anim.GetComponent<Animator>().Play("Idle");
						GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().SoundFXOutput.Stop();
					}
				}


				//player1 only needs x+ and z-
				if (P1Direction == "x+")
				{
					if (horizontal < 0 || horizontal2 < 0)
					{
						Player1.transform.rotation = Quaternion.Euler(0, 270, 0);
						GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
						if (hit.distance < 1.1)
							Player1Anim.GetComponent<Animator>().Play("Walk");
						FacingRight1 = false;
					}
					if (horizontal > 0 || horizontal2 > 0)
					{
						Player1.transform.rotation = Quaternion.Euler(0, 90, 0);
						GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
						if (hit.distance < 1.1)
							Player1Anim.GetComponent<Animator>().Play("Walk");
						FacingRight1 = true;
					}
					if(horizontal != 0)
					{
						Player1.GetComponent<Rigidbody>().velocity = new Vector3(Player1.GetComponent<Rigidbody>().velocity.x, Player1.GetComponent<Rigidbody>().velocity.y, horizontal * movementForce);
					}
					if(horizontal2 != 0)
					{
						Player1.GetComponent<Rigidbody>().velocity = new Vector3(Player1.GetComponent<Rigidbody>().velocity.x, Player1.GetComponent<Rigidbody>().velocity.y, horizontal2 * movementForce);
					}
				}
				if (P1Direction == "z-")
				{
					if (horizontal < 0 || horizontal2 < 0)
					{
						Player1.transform.rotation = Quaternion.Euler(0, 0, 0);
						GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
						if (hit.distance < 1.1)
							Player1Anim.GetComponent<Animator>().Play("Walk");
						FacingRight1 = false;
					}
					if (horizontal > 0 || horizontal2 > 0)
					{
						Player1.transform.rotation = Quaternion.Euler(0, 180, 0);
						GameObject.FindGameObjectWithTag("AudioManager").GetComponent<M_AudioManager>().PlayAudio("Step");
						if (hit.distance < 1.1)
							Player1Anim.GetComponent<Animator>().Play("Walk");
						FacingRight1 = true;
					}
					if(horizontal != 0)
					{
						Player1.GetComponent<Rigidbody>().velocity = new Vector3(horizontal * movementForce, Player1.GetComponent<Rigidbody>().velocity.y, Player1.GetComponent<Rigidbody>().velocity.z);
					}
					if(horizontal2 != 0)
					{
						Player1.GetComponent<Rigidbody>().velocity = new Vector3(horizontal2 * movementForce, Player1.GetComponent<Rigidbody>().velocity.y, Player1.GetComponent<Rigidbody>().velocity.z);
					}
				}
			}
		}

		if (Player2 && !P2Uncontroled)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray(Player2.transform.position, -Vector3.up);
			Physics.Raycast(downRay, out hit, Mathf.Infinity, layerMask);

			if (hit.distance < 1.1)
			{
				BeingCarried2 = false;
				P2OnGround = true;

			}
			else
			{
				P2OnGround = false;

			}

			if (!BeingCarried2)
			{
				if (!P2Carrying && P2OnGround)
				{
					if (hit.distance < 1.1)
					{
						if(Input.GetAxis("P2 Jump") > 0 || Input.GetAxis("A_2") > 0)
						{
							P2OnGround = false;
							Player2Anim.GetComponent<Animator>().Play("Jump");
							if (Player2.transform.GetChild(0).GetComponent<P_PickUp>().Carrying == false)
							{
								Player2.GetComponent<Rigidbody>().velocity = new Vector3(Player2.GetComponent<Rigidbody>().velocity.x, jumpForce, Player2.GetComponent<Rigidbody>().velocity.z);
								Player2Anim.GetComponent<Animator>().Play("Jump");
							}
						}
					}
				}

				//Player 2:
				float horizontal = Input.GetAxis("P2 Horizontal");
				float horizontal2 = Input.GetAxis("L_XAxis_2");
				//float vertical = Input.GetAxis ("P2_Vertical");

				//if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)){
				if (horizontal == 0 && horizontal2 == 0)
				{
					if(P2OnGround)
					{
						Player2.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
					}
					if (hit.distance < 1.1)
					{
						Player2Anim.GetComponent<Animator>().Play("Idle");
					}
				}

				//player 2 only needs x- and x+
				if (P2Direction == "x-")
				{
					if (horizontal < 0 || horizontal2 < 0)
					{
						Player2.transform.rotation = Quaternion.Euler(0, 90, 0);
						if (hit.distance < 1.1)
							Player2Anim.GetComponent<Animator>().Play("Walk");
						FacingRight2 = false;
					}
					if (horizontal > 0 || horizontal2 > 0)
					{
						Player2.transform.rotation = Quaternion.Euler(0, 270, 0);
						if (hit.distance < 1.1)
							Player2Anim.GetComponent<Animator>().Play("Walk");
						FacingRight2 = true;
					}
					if(horizontal != 0)
					{
						Player2.GetComponent<Rigidbody>().velocity = new Vector3(Player2.GetComponent<Rigidbody>().velocity.x, Player2.GetComponent<Rigidbody>().velocity.y, -horizontal * movementForce);
					}
					if(horizontal2 != 0)
					{
						Player2.GetComponent<Rigidbody>().velocity = new Vector3(Player2.GetComponent<Rigidbody>().velocity.x, Player2.GetComponent<Rigidbody>().velocity.y, -horizontal2 * movementForce);
					}
				}
				if (P2Direction == "x+")
				{
					if (horizontal < 0 || horizontal2 < 0)
					{
						Player2.transform.rotation = Quaternion.Euler(0, 270, 0);
						if (hit.distance < 1.1)
							Player2Anim.GetComponent<Animator>().Play("Walk");
						FacingRight2 = false;
					}
					if (horizontal > 0 || horizontal2 > 0)
					{
						Player2.transform.rotation = Quaternion.Euler(0, 90, 0);
						if (hit.distance < 1.1)
							Player2Anim.GetComponent<Animator>().Play("Walk");
						FacingRight2 = true;
					}
					if(horizontal != 0)
					{
						Player2.GetComponent<Rigidbody>().velocity = new Vector3(Player2.GetComponent<Rigidbody>().velocity.x, Player2.GetComponent<Rigidbody>().velocity.y, horizontal * movementForce);
					}
					if(horizontal2 != 0)
					{
						Player2.GetComponent<Rigidbody>().velocity = new Vector3(Player2.GetComponent<Rigidbody>().velocity.x, Player2.GetComponent<Rigidbody>().velocity.y, horizontal2 * movementForce);
					}
				}
			}
		}
		if (Player3)
		{
			//Cast a ray beneath the player and check that the distance from the player to the ground is less than 1, if so you can jump!!
			RaycastHit hit;
			Ray downRay = new Ray(Player3.transform.position, -Vector3.up);
			Physics.Raycast(downRay, out hit, Mathf.Infinity, layerMask);

			if (hit.distance < 1.1)
			{
				BeingCarried3 = false;
				P3OnGround = true;
			}
			else
			{
				P3OnGround = false;
			}


			if (!BeingCarried3)
			{
				if (!P3Carrying && P3OnGround)
				{
					if (hit.distance < 1.1)
					{
						if(Input.GetAxis("P3 Jump") > 0 || Input.GetAxis("A_3") > 0)
						{
							P3OnGround = false;
							Player3Anim.GetComponent<Animator>().Play("Jump");
							if (GameObject.Find("Player3").transform.GetChild(0).GetComponent<P_PickUp>().Carrying == false)
							{
								Player3.GetComponent<Rigidbody>().velocity = new Vector3(Player3.GetComponent<Rigidbody>().velocity.x, jumpForce, Player3.GetComponent<Rigidbody>().velocity.z);
								Player3Anim.GetComponent<Animator>().Play("Jump");
							}
						}
					}
				}

				//Player 3:
				float horizontal = Input.GetAxis("P3 Horizontal");
				float horizontal2 = Input.GetAxis("L_XAxis_3");
				//float vertical = Input.GetAxis ("P3_Vertical");

				//if(!Input.GetKey(KeyCode.J) && !Input.GetKey(KeyCode.L)){
				if (horizontal == 0 && horizontal2 == 0)
				{
					if(P3OnGround)
					{
						Player3.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
					}
					if (hit.distance < 1.1)
					{
						Player3Anim.GetComponent<Animator>().Play("Idle");
					}
				}



				//player3 only needs x+ and z+
				if (P3Direction == "x+")
				{
					if (horizontal < 0 || horizontal2 < 0)
					{
						Player3.transform.rotation = Quaternion.Euler(0, 270, 0);
						if (hit.distance < 1.1)
							Player3Anim.GetComponent<Animator>().Play("Walk");
						FacingRight3 = false;
					}
					if (horizontal > 0 || horizontal2 > 0)
					{
						Player3.transform.rotation = Quaternion.Euler(0, 90, 0);
						if (hit.distance < 1.1)
							Player3Anim.GetComponent<Animator>().Play("Walk");
						FacingRight3 = true;
					}
					if(horizontal != 0)
					{
						Player3.GetComponent<Rigidbody>().velocity = new Vector3(Player3.GetComponent<Rigidbody>().velocity.x, Player3.GetComponent<Rigidbody>().velocity.y, horizontal * movementForce);
					}
					if(horizontal2 != 0)
					{
						Player3.GetComponent<Rigidbody>().velocity = new Vector3(Player3.GetComponent<Rigidbody>().velocity.x, Player3.GetComponent<Rigidbody>().velocity.y, horizontal2 * movementForce);
					}
				}
				if (P3Direction == "z+")
				{
					if (horizontal < 0)
					{
						Player3.transform.rotation = Quaternion.Euler(0, 180, 0);
						if (hit.distance < 1.1)
							Player3Anim.GetComponent<Animator>().Play("Walk");
						FacingRight3 = false;
					}
					if (horizontal > 0)
					{
						Player3.transform.rotation = Quaternion.Euler(0, 0, 0);
						if (hit.distance < 1.1)
							Player3Anim.GetComponent<Animator>().Play("Walk");
						FacingRight3 = true;
					}
					if(horizontal != 0)
					{
						Player3.GetComponent<Rigidbody>().velocity = new Vector3(-horizontal * movementForce, Player3.GetComponent<Rigidbody>().velocity.y, Player3.GetComponent<Rigidbody>().velocity.x);
					}
					if(horizontal2 != 0)
					{
						Player3.GetComponent<Rigidbody>().velocity = new Vector3(-horizontal2 * movementForce, Player3.GetComponent<Rigidbody>().velocity.y, Player3.GetComponent<Rigidbody>().velocity.x);
					}
				}
			}
		}
    }
}