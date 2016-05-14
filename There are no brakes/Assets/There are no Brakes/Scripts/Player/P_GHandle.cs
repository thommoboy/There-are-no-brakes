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
		if (Input.GetKeyDown(KeyCode.Space)) {
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
		if (other.gameObject.tag == "Player" && handleInAir == false) {
			//Debug.Log ("itsa hit!");
			grabHinge = gameObject.AddComponent <CharacterJoint> ();
			grabHinge.connectedBody = other.GetComponent<Rigidbody>();
			//This stops the hook once it collides with something, and creates a HingeJoint to the object it collided with.
		}
	}
}
