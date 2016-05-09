using UnityEngine;
using System.Collections;

public class IN_BallControl : MonoBehaviour {
	public float force = 100;

	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ().AddForce (Vector3.forward * force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
}
