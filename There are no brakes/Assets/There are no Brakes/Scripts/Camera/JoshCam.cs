using UnityEngine;
using System.Linq;
using System.Collections;
//using System.Collections.Generic;

public class JoshCam : MonoBehaviour {
	private GameObject P1, P2, P3;
	private Vector3 p1, p2, p3;
	private GameObject furthestPlayer, closestPlayer;
	private float zoomDistance = 30.0f;

	[HideInInspector]
	public float[] pDists;
	private float speed = 2.0f;

	//decrease the zoom by this much when tracking players
	private float trimScalar = 12.5f;
	// - 15 tute
	//

	[HideInInspector]
	public bool Zoomed = false;
	[HideInInspector]
	public Vector3 OriginPos;

	//Zoom Limits, change these to get different max/min zoom levels
	private float zoomMin = 10.0f;
	private float zoomMax = 45.0f;

	// Use this for initialization
	void Start () {
		//pPoss = new Vector3[3];
		pDists = new float[4];
		P1 = GameObject.Find ("Player1");
		P2 = GameObject.Find ("Player2");
		P3 = GameObject.Find ("Player3");
	}

	// Update is called once per frame
	void Update () {
		p1 = P1.transform.position;
		p2 = P2.transform.position;
		p3 = P3.transform.position;

		//distance p1 - p2 is the same as p2 - p1 so only these 4 distances are needed (I THINK)
		pDists [0] = Vector3.Distance (p1,p2);
		pDists [1] = Vector3.Distance (p1,p3);
		pDists [2] = Vector3.Distance (p2,p1);
		pDists [3] = Vector3.Distance (p2,p3);
		zoomDistance = pDists.Max() + trimScalar;

		Vector3 newPos;
		//find the average of the 3 points for y and z axis and use the maximum distance between the 3 objects for the x axis
		newPos = new Vector3(/*Mathf.Clamp(zoomDistance, zoomMin, zoomDistance)*/ zoomDistance, 
			((P1.transform.position.y + P2.transform.position.y + P3.transform.position.y)/3.0f), 
			((P1.transform.position.z + P2.transform.position.z +P3.transform.position.z)/3.0f));

		//Lerp from current position to newPos
		//transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * speed);
		//Debug.Log(Zoomed);
		if (Zoomed) {
			transform.position = Vector3.Lerp (transform.position, OriginPos, 0.1f);
		} else {
			transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime * speed);
		}

	}
}
