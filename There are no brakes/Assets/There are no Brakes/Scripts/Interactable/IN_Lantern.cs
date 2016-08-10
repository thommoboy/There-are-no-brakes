/***********************
 * IN_Activation.cs
 * Originally Written by Nathan Brown
 * Modified By:
 ***********************/
using UnityEngine;
using System.Collections;

public class IN_Lantern : MonoBehaviour{
	public bool activated = false;
	public GameObject lantern;
	//public bool lever = false;
	//public bool pressureplate = false;
	//public bool lantern = false;
	private float timeout = 0.25F;
	private float nextInteract = 0.0F;
	
	void Start(){
		lantern.GetComponent<Light> ().enabled = false;
	}
	
	private bool intrigger = false;
	void OnTriggerEnter(Collider other) {
//		if(lever){
//			if(other.tag == "Player"){
//				intrigger = true;
//				if(Time.time > nextInteract){
//					if (other.name == "Player1"){
//						if (Input.GetKey (KeyCode.DownArrow)) {
//							changeState();
//						}
//					}
//					if (other.name == "Player2"){
//						if (Input.GetKey (KeyCode.S)) {
//							changeState();
//						}
//					}
//					if (other.name == "Player3"){
//						if (Input.GetKey (KeyCode.K)) {
//							changeState();
//						}
//					}
//				}
//			}
//		}
		if(/*lantern &&*/ !activated){
			if(other.tag == "Player"){
				intrigger = true;
				if (other.name == "Player1"){
					//if (Input.GetKey (KeyCode.DownArrow)) {
						//Debug.Log ("You pressed down!");
						changeState();
						lantern.GetComponent<Light> ().enabled = true;
					//}
				}
				if (other.name == "Player2"){
					//if (Input.GetKey (KeyCode.S)) {
						changeState();
						lantern.GetComponent<Light> ().enabled = true;
					//}
				}
				if (other.name == "Player3"){
					//if (Input.GetKey (KeyCode.K)) {
						changeState();
						lantern.GetComponent<Light> ().enabled = true;
					//}
				}
			}
		}
		/*if(pressureplate){
			if(other.tag == "Player" || other.tag == "Weight"){
				activated = true;
				this.transform.localScale = new Vector3(3, 2, 3);
			}
		}*/
	}
	
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player" || other.tag == "Weight"){
			intrigger = false;
		}
	}
	
	void changeState(){
		activated = !activated;
		nextInteract = Time.time + timeout;
//		if(lever){this.transform.Rotate(0, 180, 0);}
//		if(lantern){intrigger = false;}
	}
	
	
	void OnGUI(){
		if(intrigger){
			GUI.Label(new Rect (Screen.width/2 - 170, Screen.height/2 - 50, 500, 50), "Press [Interact] to use");
		}
	}
}