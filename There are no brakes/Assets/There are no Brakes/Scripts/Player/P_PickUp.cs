using UnityEngine;
using System.Collections;
 
public class P_PickUp : MonoBehaviour {	
	public float ThrowHeight = 10f;
	public float ThrowLength = 7f;
	private GameObject carriedObject;
		 
	void OnTriggerStay(Collider other){
		if(other.tag == "Player" && other.name != this.name){
			if(!Carrying){
				if(this.name == "Player1"){
					if(Input.GetKey(KeyCode.DownArrow)){
						PickUp(other.gameObject);
					}
				}
				if(this.name == "Player2"){
					if(Input.GetKey(KeyCode.S)){
						PickUp(other.gameObject);
					}
				}
			}
		}
	}

	void FixedUpdate(){
		if (Carrying) {
			if(this.name == "Player1"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight1){
					carriedObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 2.3f, this.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 2.3f, this.transform.position.z-1.2f);
				}
			}
			if(this.name == "Player2"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight2){
					carriedObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 2.3f, this.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 2.3f, this.transform.position.z-1.2f);
				}
			}
			if(this.name == "Player3"){
				if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight3){
					carriedObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 2.3f, this.transform.position.z+1.2f);
				} else {
					carriedObject.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + 2.3f, this.transform.position.z-1.2f);
				}
			}
			
			if(Input.GetKey(KeyCode.E)){
				ThrowAway();
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
		carriedObject = target;
		if (target.name == "Player1") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried1 = true;
		} else if (target.name == "Player2") {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried2 = true;
		} else {
			GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().BeingCarried3 = true;
		}
		//change other players 'parent' object
		target.transform.parent = this.transform;
	}



	void ThrowAway(){
		//disconnect other player
		HeldObject.transform.parent = null;
		//launch other player (ideallly would just take jump speed/height from player controller
		HeldObject.transform.position = new Vector3(HeldObject.transform.position.x,HeldObject.transform.position.y+0.5f,HeldObject.transform.position.z);
		if(this.name == "Player1"){
			if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight1){
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
			} else {
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
			}
		}
		if(this.name == "Player2"){
			if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight2){
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
			} else {
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
			}
		}
		if(this.name == "Player3"){
			if(GameObject.Find ("PlayerControllers").GetComponent<P_Movement> ().FacingRight3){
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, ThrowLength);
			} else {
				HeldObject.GetComponent<Rigidbody>().velocity = new Vector3(0,ThrowHeight, -ThrowLength);
			}
		}
		//can pick up things now
		Carrying = false;
	}
}