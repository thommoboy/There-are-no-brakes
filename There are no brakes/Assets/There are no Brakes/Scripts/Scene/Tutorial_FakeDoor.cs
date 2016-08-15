/***********************
 * Tutorial_FakeDoor.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;
 
public class Tutorial_FakeDoor : MonoBehaviour {
	private float timeout = 0.5F;
	private float nextInteract = 0.0F;
	public GameObject teleportTarget;
    private IN_TextTrigger_ConetentControl TextController;
	
	void Start(){
        TextController = GameObject.Find("TextObjects").GetComponent<IN_TextTrigger_ConetentControl>();
	}
	
	void Update(){
		if(intrigger){
			TextController.display = true;
			TextController.content = "Press [Interact] to use";
		}
	}
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(other.tag == "Player"){
			if (other.name == "Player2"){
				intrigger = true;
				if(Time.time > nextInteract){
					if (Input.GetAxis("P2 Interact") > 0) {
						movePlayer(other);
					}
				}
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player"){
			if (other.name == "Player2"){
				nextInteract = Time.time + timeout;
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player"){
			intrigger = false;
			TextController.display = false;
		}
	}
	
	void movePlayer(Collider other){
		other.transform.position = teleportTarget.transform.position;
	}
}