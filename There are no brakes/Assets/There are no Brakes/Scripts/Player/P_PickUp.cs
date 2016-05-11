using UnityEngine;
using System.Collections;
 
public class P_PickUp : MonoBehaviour {	
	public float ThrowHeight = 10f;
	public float ThrowLength = 7f;
		 
	void OnTriggerStay(Collider other){
		if(other.tag == "Player" && other.name != this.name){
			if(Carrying){
				if(Input.GetKey(KeyCode.W)){
					ThrowAway();
				}
			} else {
				if(Input.GetKey(KeyCode.S)){
					PickUp(other.gameObject);
				}
			}
		}
	}
	
	private bool Carrying = false;
	private GameObject HeldObject;
	void PickUp(GameObject target){
		//cant pick up anymore things
		Carrying = true;
		//get other player
		HeldObject = target;
		//move other player up
		target.transform.position = new Vector3(target.transform.position.x,target.transform.position.y+0.9f,target.transform.position.z);
		//change other players 'parent' object
		target.transform.parent = this.transform;
	}


	void ThrowAway(){
		//disconnect other player
		HeldObject.transform.parent = null;
		//launch other player (ideallly would just take jump speed/height from player controller
		HeldObject.transform.position = new Vector3(HeldObject.transform.position.x,HeldObject.transform.position.y+0.1f,HeldObject.transform.position.z);
		HeldObject.GetComponent<Rigidbody>().AddForce(0,ThrowHeight, ThrowLength, ForceMode.Impulse);
		//can pick up things now
		Carrying = false;
	}
}