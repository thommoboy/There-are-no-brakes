/***********************
 * IN_Pyramid_Door.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class IN_Pyramid_Door : MonoBehaviour {
	private float timeout = 0.25F;
	private float nextInteract = 0.0F;
	private GameObject playercontroller;
	
	void Start(){
		playercontroller = GameObject.Find("PlayerControllers");
	}
	
	void Update(){	
	}
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			intrigger = true;
			if(Time.time > nextInteract){
				if (other.name == "Player1"){
					if (Input.GetKey (KeyCode.DownArrow)) {
						movePlayer(other);
					}
				}
				if (other.name == "Player2"){
					if (Input.GetKey (KeyCode.S)) {
						movePlayer(other);
					}
				}
				if (other.name == "Player3"){
					if (Input.GetKey (KeyCode.K)) {
						movePlayer(other);
					}
				}
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player"){
			intrigger = false;
		}
	}
	
	void movePlayer(Collider other){
		nextInteract = Time.time + timeout;
		if(other.GetComponent<P_PyramidPosition>().Direction == "x+"){
			other.GetComponent<P_PyramidPosition>().Direction = "x-";
			playercontroller.GetComponent<P_Movement>().P2Direction = "x-";
		} else {
			other.GetComponent<P_PyramidPosition>().Direction = "x+";
			playercontroller.GetComponent<P_Movement>().P2Direction = "x+";
		}
		other.transform.position = new Vector3 (-other.transform.position.x,other.transform.position.y,other.transform.position.z);
	}
	
	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Interact] to use");
		}
	}
}