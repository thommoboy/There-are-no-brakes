using UnityEngine;
using System.Collections;

public class P_GHook : MonoBehaviour {
	public int speed = 10;
	public Rigidbody hookRB;
	public bool inAir;
	private HingeJoint grabHinge;

	// Use this for initialization
	void Start () {
		hookRB = GetComponent<Rigidbody> ();
		hookRB.velocity = transform.up * speed;
		inAir = true;
		//This is the direction your hook moves multiplied by speed.
	}
		
	void OnCollisionEnter (Collision col) {
		//Debug.Log (inAir);
		if (inAir == true && col.gameObject.tag == "gp") {
			hookRB.velocity = new Vector3(0, 0, 0);
			inAir = false;
			grabHinge = gameObject.AddComponent <HingeJoint>();
			grabHinge.connectedBody = col.rigidbody;
			//This stops the hook once it collides with something, and creates a HingeJoint to the object it collided with.
			//transform.rotation = new Quaternion(0,0,0,0);
		}
	}
}