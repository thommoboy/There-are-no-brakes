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
    private IN_TextTrigger_ConetentControl TextController;
	
	void Start(){
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
		lantern.GetComponent<Light>().enabled = false;
	}
	
	void Update(){
		if(intrigger && !activated){
			TextController.display = true;
			TextController.content = "Press [Interact] to use";
		}
	}
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if (other.name == "Player3"){
			intrigger = true;
			if (Input.GetKey (KeyCode.K)) {
				lantern.GetComponent<Light> ().enabled = true;
				activated = true;
				TextController.display = false;
			}
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.name == "Player3"){
			intrigger = false;
			TextController.display = false;
		}
	}
}