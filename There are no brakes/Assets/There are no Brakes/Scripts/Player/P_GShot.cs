using UnityEngine;
using System.Collections;

public class P_GShot : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate = 1.0f;
	private float nextFire = 0.0f;

	private GameObject [] grapplePoints;
	public float grappleDistance = 7.0f;
	public float springStrength = 70;
	private SpringJoint grabJoint;

	public GameObject Player1;
	public GameObject Player2;

	public Transform P1_Point;
	public Transform P2_Point;

	void Start(){
		grapplePoints = GameObject.FindGameObjectsWithTag("gp");
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.S) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//Instantiate (shot, P2_Point.position, P2_Point.rotation);
			//if distance between player and grappling hook < some value, create a hinge
			foreach(GameObject gPoint in grapplePoints){
				if(Vector3.Distance(Player2.transform.position, gPoint.transform.position) < grappleDistance){
					grabJoint = Player2.AddComponent <SpringJoint>();
					grabJoint.connectedBody = gPoint.GetComponent<Rigidbody>();
					grabJoint.autoConfigureConnectedAnchor = false;
					grabJoint.connectedAnchor = new Vector3 (0, -0.5f, 0);
					grabJoint.spring = springStrength;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.DownArrow) && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//Instantiate (shot, P1_Point.position, P1_Point.rotation);
			//if distance between player and grappling hook < some value, create a hinge
			foreach(GameObject gPoint in grapplePoints){
				//Debug.Log (Vector3.Distance (Player1.transform.position, gPoint.transform.position));
				if(Vector3.Distance(Player1.transform.position, gPoint.transform.position) < grappleDistance /* && gPoint-player distance is smallest distance in grapplePoints*/){
					grabJoint = Player1.AddComponent <SpringJoint>();
					grabJoint.connectedBody = gPoint.GetComponent<Rigidbody> ();
					grabJoint.autoConfigureConnectedAnchor = false;
					grabJoint.connectedAnchor = new Vector3 (0, -0.5f, 0);
					grabJoint.spring = springStrength;
				}
			}
		}
	}
}
