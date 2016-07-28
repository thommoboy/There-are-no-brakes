/***********************
 * P_PickUp.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class P_PickUp : MonoBehaviour {	
	public float ThrowHeight = 8f;
	public float ThrowLength = 5f;
	private GameObject carriedObject;
	private GameObject ThisPlayer;
	
	void Start(){
		ThisPlayer = this.transform.parent.gameObject;
	}
		 
	void OnTriggerStay(Collider other){
		// Checks for objects in range, dont allow player to pick up themselves
		if (other.name != ThisPlayer.name) {
			// if object is supposed to be 'pick-up-able'
			if (other.tag == "Player" || other.tag == "Weight") {
				// only looks for the interact key of the actual player (no pressing interact to make someone else interact)
				if (!Carrying) {
					if (ThisPlayer.name == "Player1") {
						if (Input.GetKeyDown(KeyCode.DownArrow)) {
							PickUp (other.gameObject);
						}
					}
					if (ThisPlayer.name == "Player2") {
						if (Input.GetKeyDown(KeyCode.S)) {
							PickUp (other.gameObject);
						}
					}
					if (ThisPlayer.name == "Player3") {
						if (Input.GetKeyDown(KeyCode.K)) {
							PickUp (other.gameObject);
						}
					}
				}
			}
		}
	}
	void Update(){
		if (Carrying) {
			if(ThisPlayer.name == "Player1"){
				// move carried object to either side if carrying player turns around
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight1){
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z-1.2f);
				}
				// throw carried object
				if(Input.GetKeyDown(KeyCode.UpArrow)){
					ThrowAway();
				}
				// drop carried object
				if(Input.GetKeyDown(KeyCode.DownArrow)){
					DropObject();
				}
				// stop player from carrying something if they get picked up
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried1){
					DropObject();
				}
			}
			if(ThisPlayer.name == "Player2"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight2){
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z-1.2f);
				}
				if(Input.GetKeyDown(KeyCode.W)){
					ThrowAway();
				}
				if(Input.GetKeyDown(KeyCode.S)){
					DropObject();
				}
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried2){
					DropObject();
				}
			}
			if(ThisPlayer.name == "Player3"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight3){
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z-1.2f);
				}
				if(Input.GetKeyDown(KeyCode.I)){
					ThrowAway();
				}
				if(Input.GetKeyDown(KeyCode.K)){
					DropObject();
				}
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried3){
					DropObject();
				}
			}
		}
	}

	
	public bool Carrying = false;
	private GameObject HeldObject;
	void PickUp(GameObject target){
		//cant pick up anymore things
		Carrying = true;
		//get other player
		HeldObject = target;
		//move carried object up
		target.transform.position = new Vector3(target.transform.position.x,target.transform.position.y+0.9f,target.transform.position.z);
		// stop carried object from falling
		target.GetComponent<Rigidbody>().useGravity = false;
		carriedObject = target;
		// let players know when they are being carried
		if (target.name == "Player1") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried1 = true;
		} else if (target.name == "Player2") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried2 = true;
		} else if (target.name == "Player3") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried3 = true;
		}
		//change carried objects 'parent' object so it moves relative to carrier
		target.transform.parent = ThisPlayer.transform;
	}



	void ThrowAway(){
		//Debug.Log ("Thrown");
		//disconnect carried object from parenting
		HeldObject.transform.parent = null;
		//launch object
		HeldObject.transform.position = new Vector3(HeldObject.transform.position.x,HeldObject.transform.position.y+0.5f,HeldObject.transform.position.z);
		// re-enable objects gravity
		HeldObject.GetComponent<Rigidbody>().useGravity = true;
		// defines which direction to throw object based on players direction
		if(ThisPlayer.name == "Player1"){
			if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight1){
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
			} else {
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
			}
		}
		if(ThisPlayer.name == "Player2"){
			if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight2){
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
			} else {
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
			}
		}
		if(ThisPlayer.name == "Player3"){
			if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight3){
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
			} else {
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
			}
		}
		//can now pick up things again
		Carrying = false;
	}
	
	void DropObject(){
		//disconnect object
		HeldObject.transform.parent = null;
		// re-enable objects gravity
		HeldObject.GetComponent<Rigidbody>().useGravity = true;
		//can now pick up things again
		Carrying = false;
	}
}