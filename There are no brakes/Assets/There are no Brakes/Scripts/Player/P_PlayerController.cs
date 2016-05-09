using UnityEngine;
using System.Collections;

public class PlayerHub : MonoBehaviour
{
	public Transform Player1;
	public Transform Player2;
	public Transform Cam;
	public Transform Target;

	public float speed = 6.0f;
	public float jumpSpeed = 8.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	private CharacterController P1CC;
	private CharacterController P2CC;

	// Use this for initialization
	void Start()
	{
		P1CC = Player1.GetComponent<CharacterController> ();
		P2CC = Player2.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update()
	{
		ControlPlayer1 ();
		ControlPlayer2 ();
		ControlCamera ();
	}

	private void ControlCamera()
	{
		
	}

	private void ControlPlayer1()
	{
		
		moveDirection = new Vector3 (Input.GetAxis("P1Horizontal"), 0, 0/*Input.GetAxis("P1Vertical")*/);
		moveDirection = Player1.TransformDirection (moveDirection);
		moveDirection *= speed;
			
		if (P1CC.isGrounded)
		{
			if (Input.GetKeyDown (KeyCode.Space))
			{
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		P1CC.Move (moveDirection * Time.deltaTime);
	}

	private void ControlPlayer2()
	{
		moveDirection = new Vector3 (Input.GetAxis("P2Horizontal"), 0, 0/*Input.GetAxis("P2Vertical")*/);
		moveDirection = Player2.TransformDirection (moveDirection);
		moveDirection *= speed;

		if (P2CC.isGrounded)
		{
			if (Input.GetKeyDown (KeyCode.Return))
			{
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		P2CC.Move (moveDirection * Time.deltaTime);
	}
}
