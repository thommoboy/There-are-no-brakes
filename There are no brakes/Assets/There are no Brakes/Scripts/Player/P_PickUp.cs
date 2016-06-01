/***********************
 * P_PickUp.cs
 * Originally Written by 
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
		if (other.tag == "Player" && other.name != ThisPlayer.name) {
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
	void Update(){
		if (Carrying) {
			if(ThisPlayer.name == "Player1"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight1){
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z-1.2f);
				}
				if(Input.GetKeyDown(KeyCode.DownArrow)){
					
					ThrowAway();
				}
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried1){
					DropPlayer();
				}
			}
			if(ThisPlayer.name == "Player2"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight2){
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z-1.2f);
				}
				if(Input.GetKeyDown(KeyCode.S)){
					ThrowAway();
				}
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried2){
					DropPlayer();
				}
			}
			if(ThisPlayer.name == "Player3"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight3){
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (ThisPlayer.transform.position.x, ThisPlayer.transform.position.y + 2.3f, ThisPlayer.transform.position.z-1.2f);
				}
				if(Input.GetKeyDown(KeyCode.K)){
					ThrowAway();
				}
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried3){
					DropPlayer();
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
		//move other player up
		target.transform.position = new Vector3(target.transform.position.x,target.transform.position.y+0.9f,target.transform.position.z);
		target.GetComponent<Rigidbody>().useGravity = false;
		carriedObject = target;
		if (target.name == "Player1") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried1 = true;
		} else if (target.name == "Player2") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried2 = true;
		} else {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried3 = true;
		}
		//change other players 'parent' object
		target.transform.parent = ThisPlayer.transform;
	}



	void ThrowAway(){
		//Debug.Log ("Thrown");
		//disconnect other player
		HeldObject.transform.parent = null;
		//launch other player (ideallly would just take jump speed/height from player controller
		HeldObject.transform.position = new Vector3(HeldObject.transform.position.x,HeldObject.transform.position.y+0.5f,HeldObject.transform.position.z);
		HeldObject.GetComponent<Rigidbody>().useGravity = true;
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
		//can pick up things now
		Carrying = false;
	}
	
	void DropPlayer(){
		//disconnect other player
		HeldObject.transform.parent = null;
		HeldObject.GetComponent<Rigidbody>().useGravity = true;
		//can pick up things now
		Carrying = false;
	}
}