using UnityEngine;
using System.Collections;

public class P_GHandle : MonoBehaviour {
	private CharacterJoint grabHinge;
	bool handleInAir;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		handleInAir = GameObject.Find ("GrapplingHook(Clone)").GetComponent<P_GHook> ().inAir;
		//Debug.Log (handleInAir);
		if (Input.GetButton ("Fire2")) {
			Destroy (GameObject.Find("GrapplingHook(Clone)"));
		}
	}

//	void OnCollisionEnter (Collision col) {
//		if (col.gameObject.tag == "player" && handleInAir == false) {
//			grabHinge = gameObject.AddComponent <HingeJoint>();
//			grabHinge.connectedBody = col.rigidbody;
//			//This stops the hook once it collides with something, and creates a HingeJoint to the object it collided with.
//		}
//	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "player" && handleInAir == false) {

			grabHinge = gameObject.AddComponent <CharacterJoint> ();
			grabHinge.connectedBody = other.GetComponent<Rigidbody>();

//			JointLimits limits = grabHinge.limits;
//			limits.min = -180;
//			limits.bounciness = 0;
//			limits.bounceMinVelocity = 0;
//			limits.max = 180;
//			grabHinge.limits = limits;
//			grabHinge.useLimits = true;
			//This stops the hook once it collides with something, and creates a HingeJoint to the object it collided with.
		}
	}
}
