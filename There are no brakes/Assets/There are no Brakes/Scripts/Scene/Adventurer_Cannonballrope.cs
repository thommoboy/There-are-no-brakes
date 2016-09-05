/***********************
 * Adventurer_Cannonballrope.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class Adventurer_Cannonballrope : MonoBehaviour {
	public GameObject[] Segment;

	// Use this for initialization
	void Start () {
		this.GetComponent<LineRenderer>().SetVertexCount(Segment.Length+1);
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<LineRenderer>().SetPosition(0, this.transform.position);
		for(var i = 0; i < Segment.Length; i++){
			this.GetComponent<LineRenderer>().SetPosition(i+1, Segment[i].transform.position);
		}
	}
}
