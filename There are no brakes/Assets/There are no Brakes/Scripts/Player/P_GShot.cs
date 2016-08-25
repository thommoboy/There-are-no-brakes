/***********************
 * P_GShot.cs
 * Originally Written by Joshua Garvey
 * Modified By:
 *  Pierce Thompson - Addition of Controller support, Cleaning of code
 ***********************/
using UnityEngine;
using System.Collections;

public class P_GShot : MonoBehaviour
{
	public float grappleDistance = 10.0f;
	private float springStrength = 300;
	public float springMaxDistance = 2;

	public Shader shader;
	public Texture texture;

	private SpringJoint grabJoint;

	private GameObject [] grapplePoints;

	private GameObject currentGPoint1;

	private LineRenderer rope1;

	private bool hook1Active = false;

	public GameObject Player1;

	void Start(){
		grapplePoints = GameObject.FindGameObjectsWithTag("gp");
	}

	// Update is called once per frame
	void Update ()
	{
		if((Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) && hook1Active == false) {
			//if distance between player and grappling hook < some value, create a hinge

			foreach(GameObject gPoint in grapplePoints){
				//Debug.Log (Vector3.Distance (Player1.transform.position, gPoint.transform.position));
				if(Vector3.Distance(Player1.transform.position, gPoint.transform.position) < grappleDistance /* && gPoint-player distance is smallest distance in grapplePoints*/){
					hook1Active = true;
					currentGPoint1 = gPoint;
					grabJoint = Player1.AddComponent <SpringJoint>();
					grabJoint.connectedBody = gPoint.GetComponent<Rigidbody> ();
					grabJoint.autoConfigureConnectedAnchor = false;
					grabJoint.connectedAnchor = new Vector3 (-0.5f, 0, 0);
					grabJoint.spring = springStrength;
					grabJoint.enableCollision = true;
					grabJoint.maxDistance = springMaxDistance;
					grabJoint.tolerance = 1;
					rope1 = Player1.AddComponent<LineRenderer> ();
					rope1.material = new Material(shader);
					rope1.material.mainTexture = texture;
					rope1.SetWidth (0.25f, 0.25f);
					//rope1.material.color = color;
				}
			}
		} else if ((Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) && hook1Active == true) {
			hook1Active = false;
			Destroy(Player1.GetComponent<SpringJoint> ());
			Destroy (Player1.GetComponent<LineRenderer> ());
		}
//		//keyboard inputs
//		if(Input.GetKeyDown(KeyCode.DownArrow) && hook1Active == false) {
//			//if distance between player and grappling hook < some value, create a hinge
//
//			foreach(GameObject gPoint in grapplePoints){
//				//Debug.Log (Vector3.Distance (Player1.transform.position, gPoint.transform.position));
//				if(Vector3.Distance(Player1.transform.position, gPoint.transform.position) < grappleDistance /* && gPoint-player distance is smallest distance in grapplePoints*/){
//					hook1Active = true;
//					currentGPoint1 = gPoint;
//					grabJoint = Player1.AddComponent <SpringJoint>();
//					grabJoint.connectedBody = gPoint.GetComponent<Rigidbody> ();
//					grabJoint.autoConfigureConnectedAnchor = false;
//					grabJoint.connectedAnchor = new Vector3 (-0.5f, 0, 0);
//					grabJoint.spring = springStrength;
//					grabJoint.enableCollision = true;
//					grabJoint.maxDistance = springMaxDistance;
//					grabJoint.tolerance = 1;
//					rope1 = Player1.AddComponent<LineRenderer> ();
//					rope1.material = new Material(shader);
//					rope1.material.mainTexture = texture;
//					rope1.SetWidth (0.25f, 0.25f);
//					//rope1.material.color = color;
//				}
//			}
//		} else if ((Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) && hook1Active == true) {
//			hook1Active = false;
//			Destroy(Player1.GetComponent<SpringJoint> ());
//			Destroy (Player1.GetComponent<LineRenderer> ());
//		}

		if (hook1Active == true) {
			rope1.SetPosition (0, Player1.transform.position);
			rope1.SetPosition (1, currentGPoint1.transform.position);
		}

		//if the joint breaks, destory the visualisation of the joint
		if (!Player1.GetComponent<SpringJoint> () && Player1.GetComponent<LineRenderer>()) {
			Destroy (Player1.GetComponent<LineRenderer>());
		}
    }
}
