using UnityEditor;
using UnityEngine;
using System.Collections;

public class P_GShot : MonoBehaviour {
//	public GameObject shot;
//	public Transform shotSpawn;
//	public float fireRate = 1.0f;
//	private float nextFire = 0.0f;

	public float grappleDistance = 10.0f;
	public float springStrength = 60;

	public Shader shader;
	public Texture texture;
	//public Color color;

	private SpringJoint grabJoint;

	private GameObject [] grapplePoints;

	private GameObject currentGPoint1;
	private GameObject currentGPoint2;

	private LineRenderer rope1;
	private LineRenderer rope2;

	private bool hook1Active = false;
	private bool hook2Active = false;

	public GameObject Player1;
	public GameObject Player2;

//	public Transform P1_Point;
//	public Transform P2_Point;

	void Start(){
		grapplePoints = GameObject.FindGameObjectsWithTag("gp");
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow) && hook1Active == false)
		{
			//nextFire = Time.time + fireRate;
			//Instantiate (shot, P1_Point.position, P1_Point.rotation);
			//if distance between player and grappling hook < some value, create a hinge

			foreach(GameObject gPoint in grapplePoints){
				//Debug.Log (Vector3.Distance (Player1.transform.position, gPoint.transform.position));
				if(Vector3.Distance(Player1.transform.position, gPoint.transform.position) < grappleDistance /* && gPoint-player distance is smallest distance in grapplePoints*/){
					hook1Active = true;
					currentGPoint1 = gPoint;
					grabJoint = Player1.AddComponent <SpringJoint>();
					grabJoint.connectedBody = gPoint.GetComponent<Rigidbody> ();
					grabJoint.autoConfigureConnectedAnchor = false;
					grabJoint.connectedAnchor = new Vector3 (0, -0.5f, 0);
					grabJoint.spring = springStrength;
					rope1 = Player1.AddComponent<LineRenderer> ();
					rope1.material = new Material(shader);
					rope1.material.mainTexture = texture;
					rope1.SetWidth (0.5f, 0.5f);
					//rope1.material.color = color;
				}
			}
		} else if (Input.GetKeyDown (KeyCode.DownArrow) && hook1Active == true) {
			hook1Active = false;
			Destroy(Player1.GetComponent<SpringJoint> ());
			Destroy (Player1.GetComponent<LineRenderer> ());
		}

		if (hook1Active == true) {
			rope1.SetPosition (0, Player1.transform.position);
			rope1.SetPosition (1, currentGPoint1.transform.position);
		}

		//if the joint breaks, destory the visualisation of the joint
		if (!Player1.GetComponent<SpringJoint> () && Player1.GetComponent<LineRenderer>()) {
			Destroy (Player1.GetComponent<LineRenderer>());
		}

		if (Input.GetKeyDown (KeyCode.S) && hook2Active == false) {
			//nextFire = Time.time + fireRate;
			//Instantiate (shot, P2_Point.position, P2_Point.rotation);
			//if distance between player and grappling hook < some value, create a hinge

			foreach (GameObject gPoint in grapplePoints) {
				if (Vector3.Distance (Player2.transform.position, gPoint.transform.position) < grappleDistance) {
					hook2Active = true;
					currentGPoint2 = gPoint;
					grabJoint = Player2.AddComponent <SpringJoint> ();
					grabJoint.connectedBody = gPoint.GetComponent<Rigidbody> ();
					grabJoint.autoConfigureConnectedAnchor = false;
					grabJoint.connectedAnchor = new Vector3 (0, -0.5f, 0);
					grabJoint.spring = springStrength;
					rope2 = Player2.AddComponent<LineRenderer> ();
					rope2.material = new Material(shader);
					rope2.material.mainTexture = texture;
					rope2.SetWidth (0.5f, 0.5f);
				}
			}
		} else if (Input.GetKeyDown (KeyCode.S) && hook2Active == true) {
			hook2Active = false;
			Destroy(Player2.GetComponent<SpringJoint> ());
			Destroy (Player2.GetComponent<LineRenderer> ());
		}

		if (hook2Active == true) {
			rope2.SetPosition (0, Player2.transform.position);
			rope2.SetPosition (1, currentGPoint2.transform.position);
		}

		//if the joint breaks, destory the visualisation of the joint
		if (!Player1.GetComponent<SpringJoint> () && Player1.GetComponent<LineRenderer>()) {
			Destroy (Player1.GetComponent<LineRenderer>());
		}
	}
}
