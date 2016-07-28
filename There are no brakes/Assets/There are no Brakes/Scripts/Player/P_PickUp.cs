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
	private float timeout = 0.5F;
	private float nextInteract = 0.0F;
	
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
				if(Input.GetKeyDown(KeyCode.UpArrow) && Time.time > nextInteract){
					ThrowAway();
				}
				// drop carried object
				if(Input.GetKeyDown(KeyCode.DownArrow) && Time.time > nextInteract){
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
				if(Input.GetKeyDown(KeyCode.W) && Time.time > nextInteract){
					ThrowAway();
				}
				if(Input.GetKeyDown(KeyCode.S) && Time.time > nextInteract){
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
				if(Input.GetKeyDown(KeyCode.I) && Time.time > nextInteract){
					ThrowAway();
				}
				if(Input.GetKeyDown(KeyCode.K) && Time.time > nextInteract){
					DropObject();
				}
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried3){
					DropObject();
				}
			}
		} else {
			//timeout to stop player jumping right after throwing object
			if(Time.time > nextInteract){
				if (ThisPlayer.name == "Player1") {
					GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().P1Carrying = false;
				} else if (ThisPlayer.name == "Player2"){
					GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().P2Carrying = false;
				} else if (ThisPlayer.name== "Player3") {
					GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().P3Carrying = false;
				}
			}
		}
	}

	
	public bool Carrying = false;
	private GameObject HeldObject;
	void PickUp(GameObject target){
		//stop player dropping object soon as they pick it up
		nextInteract = Time.time + timeout;
		//cant pick up anymore things
		Carrying = true;
		if (ThisPlayer.name == "Player1") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().P1Carrying = true;
		} else if(ThisPlayer.name == "Player2"){
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().P2Carrying = true;
		} else if(ThisPlayer.name== "Player3") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().P3Carrying = true;
		}
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
		DropObject();
		//launch object
		HeldObject.transform.position = new Vector3(HeldObject.transform.position.x,HeldObject.transform.position.y+0.5f,HeldObject.transform.position.z);
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
	}
	
	void DropObject(){
		//disconnect object
		HeldObject.transform.parent = null;
		// re-enable objects gravity
		HeldObject.GetComponent<Rigidbody>().useGravity = true;
		//can now pick up things again
		Carrying = false;
		//stop player jumping right after they throw object
		nextInteract = Time.time + timeout;
	}
}