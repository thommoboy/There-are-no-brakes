/***********************
 * IN_Lantern.cs
 * Originally Written by Joshua
 * Modified By:
	Nathan Brown (Bug fixes)
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Lantern : MonoBehaviour{
	public bool activated = false;
	public GameObject lantern;
	
	void Start(){
		lantern.GetComponent<Light>().enabled = false;
	}
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if (other.name == "Player3"){
			intrigger = true;
			if (Input.GetKey (KeyCode.K)) {
				lantern.GetComponent<Light> ().enabled = true;
				activated = true;
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.name == "Player3"){
			intrigger = false;
		}
	}
	
	
	void OnGUI(){
		if(intrigger && !activated){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Interact] to use");
		}
	}
}