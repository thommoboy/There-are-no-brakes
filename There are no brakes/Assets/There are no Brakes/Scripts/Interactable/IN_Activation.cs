/***********************
 * IN_Activation.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Activation : MonoBehaviour{
	public bool activated = false;
	public bool lever = false;
	public bool pressureplate = false;
	private float timeout = 0.25F;
	private float nextInteract = 0.0F;
	
	void Start(){
	}
	
	private bool intrigger = false;
	void OnTriggerStay(Collider other) {
		if(lever){
			if(other.tag == "Player"){
				intrigger = true;
				if(Time.time > nextInteract){
					if (other.name == "Player1"){
						if (Input.GetKey (KeyCode.DownArrow)) {
							changeState();
						}
					}
					if (other.name == "Player2"){
						if (Input.GetKey (KeyCode.S)) {
							changeState();
						}
					}
					if (other.name == "Player3"){
						if (Input.GetKey (KeyCode.K)) {
							changeState();
						}
					}
				}
			}
		}
		if(pressureplate){
			if(other.tag == "Player" || other.tag == "Weight"){
				activated = true;
				this.transform.localScale = new Vector3(3, 2, 3);
			}
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player" || other.tag == "Weight"){
			if(lever){
				intrigger = false;
			}
			if(pressureplate){
				activated = false;
				this.transform.localScale = new Vector3(3, 4, 3);
			}
		}
	}
	
	void changeState(){
		activated = !activated;
		nextInteract = Time.time + timeout;
		this.transform.Rotate(0, 180, 0);
	}
	
	
	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Interact] to use");
		}
	}
}