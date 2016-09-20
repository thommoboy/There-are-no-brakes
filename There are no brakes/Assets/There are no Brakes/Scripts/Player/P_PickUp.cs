﻿/***********************
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
	private GameObject PlayerController;
	private float timeout = 0.5F;
	private float nextInteract = 0.0F;
	public bool isAncientLevel;
	public bool isTutorialLevel;
	public bool isIndustrialLevel;

	void Start(){
		ThisPlayer = this.transform.parent.gameObject;
		PlayerController = GameObject.Find ("PlayerControllers");
	}
		 
	void OnTriggerStay(Collider other){
		// Checks for objects in range, dont allow player to pick up themselves
		if (other.name != ThisPlayer.name && other.name != "PulleyBlocker") {
			// if object is supposed to be 'pick-up-able'
			if ((other.tag == "Player" || other.tag == "Weight") && !isAncientLevel) {
				// check that player isnt already carrying something 
				if (!Carrying) {
					// check that player is on the ground
					if (ThisPlayer.name == "Player1" && PlayerController.GetComponent<P_Movement> ().P1OnGround) {
						// only looks for the interact key of the actual player (no pressing interact to make someone else interact)
						// uses timeout to prevent player picking up someone right after dropping them
						if ((Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) && Time.time > nextInteract) {
							PickUp (other.gameObject);
						}
					}
					if (ThisPlayer.name == "Player2" && PlayerController.GetComponent<P_Movement> ().P2OnGround) {
						if ((Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) && Time.time > nextInteract) {
							PickUp (other.gameObject);
						}
					}
					if (ThisPlayer.name == "Player3" && PlayerController.GetComponent<P_Movement> ().P3OnGround) {
						if ((Input.GetAxis("P3 Interact") > 0 || Input.GetAxis("B_3") > 0) && Time.time > nextInteract) {
							PickUp (other.gameObject);
						}
					}
				}
			}
			if (other.tag == "Weight" && isAncientLevel) {
				if (ThisPlayer.name == "Player1" && PlayerController.GetComponent<P_Movement> ().P1OnGround) {
					if ((Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) && Time.time > nextInteract) {
						PickUp (other.gameObject);
					}
				}
				if (ThisPlayer.name == "Player2" && PlayerController.GetComponent<P_Movement> ().P2OnGround) {
					if ((Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) && Time.time > nextInteract) {
						PickUp (other.gameObject);
					}
				}
				if (ThisPlayer.name == "Player3" && PlayerController.GetComponent<P_Movement> ().P3OnGround) {
					if ((Input.GetAxis("P3 Interact") > 0 || Input.GetAxis("B_3") > 0) && Time.time > nextInteract) {
						PickUp (other.gameObject);
					}
				}
			}
		}
	}
	void Update(){
		float carryHeight = 2.3f;
		float carryDistance = 1.2f;
		if (Carrying) {
			//dont put boxes too high or too close
			if(carriedObject.tag == "Weight"){
				carryHeight = 1.1f;
				carryDistance = 0.7f;
			}
			//stops players going through MOST roofs
			if (isIndustrialLevel) {
				carryHeight = 1.1f;
				carryDistance = 0.6f;
			}
			if(ThisPlayer.name == "Player1"){
				// move carried object to either side if carrying player turns around, taking direction into account
				if(PlayerController.GetComponent<P_Movement> ().P1Direction == "x+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight1){
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z+carryDistance);
					} else {
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z-carryDistance);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().P1Direction == "z-"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight1){
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x+carryDistance, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z);
					} else {
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x-carryDistance, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z);
					}
				}
				// throw carried object
				if((Input.GetAxis("P1 Jump") > 0 || Input.GetAxis("A_1") > 0) && Time.time > nextInteract){
					if(carriedObject.tag != "Weight"){
						ThrowAway();
					}
				}
				// drop carried object
				if((Input.GetAxis("P1 Interact") > 0 || Input.GetAxis("B_1") > 0) && Time.time > nextInteract){
					if (PlayerController.GetComponent<P_Movement> ().P1OnGround) {
						DropObject (false);
					}
				}
				// stop player from carrying something if they get picked up
				if(PlayerController.GetComponent<P_Movement> ().BeingCarried1){
					DropObject(false);
				}
				// stop player from carrying another player while in the air
				if(!PlayerController.GetComponent<P_Movement> ().P1OnGround){
					if(PlayerController.GetComponent<P_Movement> ().BeingCarried2 || PlayerController.GetComponent<P_Movement> ().BeingCarried3){
						DropObject(false);
					}
				}
			}
			if(ThisPlayer.name == "Player2"){
				if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight2){
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z+carryDistance);
					} else {
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z-carryDistance);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x-"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight2){
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z-carryDistance);
					} else {
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z+carryDistance);
					}
				}
				if((Input.GetAxis("P2 Jump") > 0 || Input.GetAxis("A_2") > 0) && Time.time > nextInteract){
					if(carriedObject.tag != "Weight"){
						ThrowAway();
					}
				}
				if((Input.GetAxis("P2 Interact") > 0 || Input.GetAxis("B_2") > 0) && Time.time > nextInteract){
					if (PlayerController.GetComponent<P_Movement> ().P2OnGround) {
						DropObject (false);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().BeingCarried2){
					DropObject(false);
				}
				if(!PlayerController.GetComponent<P_Movement> ().P2OnGround){
					if(PlayerController.GetComponent<P_Movement> ().BeingCarried1 || PlayerController.GetComponent<P_Movement> ().BeingCarried3){
						DropObject(false);
					}
				}
			}
			if(ThisPlayer.name == "Player3"){
				if(PlayerController.GetComponent<P_Movement> ().P3Direction == "x+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight3){
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z+carryDistance);
					} else {
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z-carryDistance);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().P3Direction == "z+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight3){
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x-carryDistance, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z);
					} else {
						carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x+carryDistance, ThisPlayer.transform.position.y + carryHeight, ThisPlayer.transform.position.z);
					}
				}
				if((Input.GetAxis("P3 Jump") > 0 || Input.GetAxis("A_3") > 0) && Time.time > nextInteract){
					if(carriedObject.tag != "Weight"){
						ThrowAway();
					}
				}
				if((Input.GetAxis("P3 Interact") > 0 || Input.GetAxis("B_3") > 0) && Time.time > nextInteract){
					if (PlayerController.GetComponent<P_Movement> ().P3OnGround) {
						DropObject (false);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().BeingCarried3){
					DropObject(false);
				}
				if(!PlayerController.GetComponent<P_Movement> ().P3OnGround){
					if(PlayerController.GetComponent<P_Movement> ().BeingCarried1 || PlayerController.GetComponent<P_Movement> ().BeingCarried2){
						DropObject(false);
					}
				}
			}
		} else {
			//timeout to stop player jumping right after throwing object
			if(Time.time > nextInteract){
				if (ThisPlayer.name == "Player1") {
					PlayerController.GetComponent<P_Movement> ().P1Carrying = false;
				} else if (ThisPlayer.name == "Player2"){
					PlayerController.GetComponent<P_Movement> ().P2Carrying = false;
				} else if (ThisPlayer.name== "Player3") {
					PlayerController.GetComponent<P_Movement> ().P3Carrying = false;
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
		if(target.tag != "Weight"){
			if (isIndustrialLevel){
				//swap to a box collider to make limiting player movement easier (for wall hax in industrial level)
				ThisPlayer.GetComponentInParent<CapsuleCollider> ().enabled = false;
				ThisPlayer.GetComponentInParent<BoxCollider> ().enabled = true;
				ThisPlayer.GetComponentInParent<BoxCollider> ().size = new Vector3(1.5f, ThisPlayer.GetComponentInParent<BoxCollider> ().size.y, ThisPlayer.GetComponentInParent<BoxCollider> ().size.z);
				ThisPlayer.GetComponentInParent<BoxCollider> ().center = new Vector3(-0.2f, ThisPlayer.GetComponentInParent<BoxCollider> ().center.y, ThisPlayer.GetComponentInParent<BoxCollider> ().center.z);
				//ThisPlayer.GetComponentInParent<CapsuleCollider> ().radius = 1.5f;
				//ThisPlayer.GetComponentInParent<CapsuleCollider> ().center = new Vector3(ThisPlayer.GetComponentInParent<CapsuleCollider> ().center.x, ThisPlayer.GetComponentInParent<CapsuleCollider> ().center.y+0.5f,ThisPlayer.GetComponentInParent<CapsuleCollider> ().center.z);
			}
				if (ThisPlayer.name == "Player1") {
				PlayerController.GetComponent<P_Movement> ().P1Carrying = true;
			} else if(ThisPlayer.name == "Player2"){
				PlayerController.GetComponent<P_Movement> ().P2Carrying = true;
			} else if(ThisPlayer.name== "Player3") {
				PlayerController.GetComponent<P_Movement> ().P3Carrying = true;
			}
		} else if (!isTutorialLevel) {
			target.GetComponent<Collider> ().enabled = false;
		}

		//get other player
		HeldObject = target;
		target.transform.position = new Vector3 (target.transform.position.x, target.transform.position.y + 0.9f, target.transform.position.z);

		// stop carried object from falling
		target.GetComponent<Rigidbody>().useGravity = false;
		carriedObject = target;
		// let players know when they are being carried
		if (target.name == "Player1") {
			PlayerController.GetComponent<P_Movement> ().BeingCarried1 = true;
		} else if (target.name == "Player2") {
			PlayerController.GetComponent<P_Movement> ().BeingCarried2 = true;
		} else if (target.name == "Player3") {
			PlayerController.GetComponent<P_Movement> ().BeingCarried3 = true;
		}
		//change carried objects 'parent' object so it moves relative to carrier
		target.transform.parent = ThisPlayer.transform;
	}



	void ThrowAway(){
		//launch object
		DropObject(false);
		//set launch position
		HeldObject.transform.position = new Vector3(HeldObject.transform.position.x,HeldObject.transform.position.y+0.5f,HeldObject.transform.position.z);
		//dont put boxes too high
		if(HeldObject.tag == "Weight"){
			HeldObject.transform.position = new Vector3(HeldObject.transform.position.x,HeldObject.transform.position.y-0.4f,HeldObject.transform.position.z);
		} else if (isIndustrialLevel){
			HeldObject.transform.position = new Vector3(this.transform.position.x,this.transform.position.y+2f,this.transform.position.z);
		}
		// defines which direction to throw object based on players direction
		if(carriedObject.tag != "Weight"){
			if(ThisPlayer.name == "Player1"){
				if(PlayerController.GetComponent<P_Movement> ().P1Direction == "x+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight1){
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
					} else {
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().P1Direction == "z-"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight1){
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(ThrowLength,ThrowHeight, 0);
					} else {
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(-ThrowLength,ThrowHeight, 0);
					}
				}
			}
			if(ThisPlayer.name == "Player2"){
				if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight2){
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
					} else {
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().P2Direction == "x-"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight2){
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
					} else {
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
					}
				}
			}
			if(ThisPlayer.name == "Player3"){
				if(PlayerController.GetComponent<P_Movement> ().P3Direction == "x+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight3){
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
					} else {
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
					}
				}
				if(PlayerController.GetComponent<P_Movement> ().P3Direction == "z+"){
					if(PlayerController.GetComponent<P_Movement> ().FacingRight3){
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(-ThrowLength,ThrowHeight, 0);
					} else {
						HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(ThrowLength,ThrowHeight, 0);
					}
				}
			}
		}
	}
	
	public void DropObject(bool external){ 
		if(Carrying){
			if(isIndustrialLevel){
				ThisPlayer.GetComponentInParent<CapsuleCollider> ().enabled = true;
				ThisPlayer.GetComponentInParent<BoxCollider> ().enabled = false;
				ThisPlayer.GetComponentInParent<BoxCollider> ().size = new Vector3(1.0f, ThisPlayer.GetComponentInParent<BoxCollider> ().size.y, ThisPlayer.GetComponentInParent<BoxCollider> ().size.z);
				ThisPlayer.GetComponentInParent<BoxCollider> ().center = new Vector3(0.0f, ThisPlayer.GetComponentInParent<BoxCollider> ().center.y, ThisPlayer.GetComponentInParent<BoxCollider> ().center.z);
				//ThisPlayer.GetComponentInParent<CapsuleCollider> ().radius = 0.5f;
				//ThisPlayer.GetComponentInParent<CapsuleCollider> ().center = new Vector3(ThisPlayer.GetComponentInParent<CapsuleCollider> ().center.x, ThisPlayer.GetComponentInParent<CapsuleCollider> ().center.y-0.5f,ThisPlayer.GetComponentInParent<CapsuleCollider> ().center.z);
			}
				//disconnect object
			HeldObject.transform.parent = null;
			// re-enable objects gravity
			HeldObject.GetComponent<Rigidbody>().useGravity = true;
			//can now pick up things again
			Carrying = false;
			if(HeldObject.tag == "Weight"){
				HeldObject.GetComponent<Collider> ().enabled = true;
//				if (isTutorialLevel) {
//					//default
//					HeldObject.layer = 0;
//				}
			}
			//stop player jumping right after they throw object
			nextInteract = Time.time + timeout;
		}
		//Prevents bugs if triggered by other script 
		if(external){
			HeldObject = null;
		} 
	}
}