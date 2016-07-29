/***********************
 * Tutorial_FakeDoor.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class Tutorial_FakeDoor : MonoBehaviour {
	private float timeout = 0.25F;
	private float nextInteract = 0.0F;
	
	void Start(){
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
		other.transform.position = new Vector3 (other.transform.position.x,other.transform.position.y,307);
	}
	
	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Interact] to use");
		}
	}
}