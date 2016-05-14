using UnityEngine;
using System.Collections;

public class IN_WallPiece : MonoBehaviour {
	float myTime;
	// Use this for initialization
	void Start () {
		myTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float appearTime = Time.time - myTime;
		if (appearTime > 4) {
			return;
		}
		Color c = GetComponent<Renderer> ().material.color;
		c.a = (float)(1.1 - appearTime / 4);
		GetComponent<Renderer> ().material.color = c;
		//print (c.a.ToString ());
	}
}
